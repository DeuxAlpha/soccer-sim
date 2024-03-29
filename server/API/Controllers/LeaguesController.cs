﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Dtos.Requests;
using API.Dtos.Responses;
using API.Dtos.Views;
using API.Dtos.Views.Table;
using API.Services;
using Database.Contexts;
using Database.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Infer;
using DynamicQuerying.Main.Query.Models;
using DynamicQuerying.Main.Query.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.ML.Probabilistic.Math;
using Serilog;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaguesController : ControllerBase
    {
        private readonly SoccerSimContext _context;
        private readonly SeasonProcessingService _seasonProcessingService;

        public LeaguesController(SoccerSimContext context, SeasonProcessingService seasonProcessingService)
        {
            _context = context;
            _seasonProcessingService = seasonProcessingService;
        }

        [HttpGet]
        [Obsolete($"Use OPTIONS:query:{nameof(GetLeagueOptions)}({nameof(QueryRequest)}) instead.")]
        public ActionResult<QueryResponse<LeagueDto>> GetLeagues([FromQuery] QueryRequest queryRequest)
        {
            return Ok(QueryService.GetQueryResponse(_context.Leagues.Select(c => new LeagueDto(c)), queryRequest));
        }
        
        [HttpOptions("query")]
        public ActionResult<QueryResponse<LeagueDto>> GetLeagueOptions([FromBody] QueryRequest queryRequest)
        {
            return Ok(QueryService.GetQueryResponse(_context.Leagues.Select(c => new LeagueDto(c)), queryRequest));
        }

        [HttpGet("divisions/{division}/{season}")]
        public ActionResult<LeagueDto[]> GetLeaguesInDivision(string division, string season)
        {
            return Ok(_context.Leagues
                .Where(l => l.DivisionName == division && l.Season == season)
                .Select(l => new LeagueDto(l)));
        }

        [HttpGet("{name}")]
        public ActionResult<LeagueDto[]> GetLeaguesByName(string name)
        {
            return Ok(_context.Leagues.Where(c => c.Name == name).Select(c => new LeagueDto(c)));
        }

        [HttpGet("seasons/{season}")]
        public ActionResult<LeagueDto[]> GetLeaguesBySeason(string season)
        {
            return Ok(_context.Leagues.Where(c => c.Season == season).Select(c => new LeagueDto(c)));
        }

        [HttpGet("{name}/{season}")]
        public async Task<ActionResult<LeagueDto>> GetLeague(string name, string season)
        {
            var league = await _context.Leagues.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (league == null) return NotFound(new { name, season });
            return Ok(new LeagueDto(league));
        }

        [HttpGet("{name}/{season}/matches")]
        public async Task<ActionResult<MatchInfoDto>> GetMatches(string name, string season)
        {
            var gameDays = await _context.LeagueGameDays
                .Include(l => l.Fixtures)
                .Where(l => l.LeagueName == name && l.Season == season)
                .ToListAsync();
            if (gameDays.Count == 0)
            {
                return NotFound(new { name, season });
            }
            return Ok(new MatchInfoDto
            {
                LastMatchDay = gameDays.Max(gd => gd.GameDayNumber),
                LastCompletedMatchDay = gameDays
                    .SelectMany(gd => gd.Fixtures
                        .Select(f => f.GameDayNumber))
                    .Max(n => n)
            });
        }

        [HttpGet("{name}/{season}/fixtures/{gameDay}")]
        public async Task<ActionResult<ResultDto[]>> GetLeagueFixture(string name, string season, int gameDay)
        {
            var fixtures = await _context.LeagueFixtures
                .Include(f => f.Events)
                .Where(gd => gd.LeagueName == name && gd.Season == season && gd.GameDayNumber == gameDay)
                .ToListAsync();
            var results = fixtures.Select(fixture => new ResultDto(fixture)).ToList();

            return Ok(results);
        }

        // TODO: Update table with promotion data.
        [HttpGet("{name}/{season}/table")]
        public async Task<ActionResult<TableDto>> GetLeagueTable(string name, string season)
        {
            var table = await _seasonProcessingService.GetTable(name, season);

            return Ok(table);
        }

        [HttpPost("{name}/{season}/rank/{gameDay:int}")]
        public async Task<ActionResult> GetLeagueRanks(
            string name,
            string season,
            int gameDay,
            [FromBody] StrengthRequest strengthRequest)
        {
            var league = await _context.Leagues.SingleOrDefaultAsync(league => league.Name == name &&
                                                                               league.Season == season);
            if (league == null)
                return NotFound
                (new
                    { Messsage = "No league exists by that name or season.", Ref = new { name, season } });
            var fixtures = await _context.LeagueFixtures
                .Include(f => f.Events)
                .Where(gd => gd.LeagueName == name && gd.Season == season && gd.GameDayNumber <= gameDay)
                .ToListAsync();
            var results = fixtures.Select(fixture => new ResultDto(fixture)).ToList();
            var homeTeams = results.Select(result => result.HomeTeamName).ToList();
            var awayTeams = results.Select(result => result.AwayTeamName).ToList();
            var teamsWithIds = homeTeams.Concat(awayTeams).Distinct().Select((team, teamId) => new
            {
                TeamName = team,
                TeamId = teamId
            }).ToList();
            var resultsWithIds = results.Select(result => new
            {
                Result = result,
                HomeId = teamsWithIds.First(t => t.TeamName == result.HomeTeamName).TeamId,
                AwayId = teamsWithIds.First(t => t.TeamName == result.AwayTeamName).TeamId,
            }).ToList();
            var winnerIds = resultsWithIds.Select(r =>
                r.Result.HomeGoals > r.Result.AwayGoals ? r.HomeId :
                r.Result.AwayGoals > r.Result.HomeGoals ? r.AwayId :
                -1).Where(id => id >= 0).ToList();
            var loserIds = resultsWithIds.Select(r =>
                r.Result.HomeGoals < r.Result.AwayGoals ? r.HomeId :
                r.Result.AwayGoals < r.Result.HomeGoals ? r.AwayId :
                -1).Where(id => id >= 0).ToList();
            var strengths = StrengthAssigner.AssignStrengths(new StrengthRequest
            {
                AverageStrength = strengthRequest.AverageStrength,
                StrengthVariance = strengthRequest.StrengthVariance,
                WinnerIds = winnerIds,
                LoserIds = loserIds
            });
            var strengthsAndTeams = strengths.IdToStrengthsDictionary.Select(idAndStrength => new
            {
                teamsWithIds.First(t => t.TeamId == idAndStrength.Key).TeamName,
                Strength = double.Parse(idAndStrength.Value.ToString()
                    .Split("(").Last()
                    .Split(",").First())
            });

            return Ok(strengthsAndTeams);
        }

        [HttpGet("{name}/{season}/table/{gameDay}")]
        public async Task<ActionResult<TableDto>> GetLeagueTable(string name, string season, int gameDay)
        {
            var table = await _seasonProcessingService.GetTable(name, season, gameDay);

            return Ok(table);
        }
        
        [HttpGet("{name}/{season}/promoted-relegated")]
        public async Task<ActionResult<PromoRelegationOverviewDto>> GetPromotedTeams(string name, string season)
        {
            var league = await _context.Leagues
                .Include(l => l.Teams)
                .FirstOrDefaultAsync(l => l.Name == name && l.Season == season);
            if (league == null) return NotFound(new { name, season });
            var teams = league.Teams.ToList();
            var table = new TableDto(teams);
            var fixtures = await _context.LeagueFixtures
                .Include(f => f.Events)
                .Include(f => f.HomeTeam)
                .Include(f => f.AwayTeam)
                .Where(f => f.LeagueName == name && f.Season == season)
                .ToListAsync();
            foreach (var fixture in fixtures)
            {
                table.AddFixture(new ResultDto(fixture));
            }

            table.ApplyPositions();

            var response = new PromoRelegationOverviewDto
            {
                PromotedTeams = await _seasonProcessingService.GetPromotedTeams(name, season),
                RelegatedTeams = await _seasonProcessingService.GetRelegatedTeams(name,  season),
                PromoPlayoffTeams = await _seasonProcessingService.GetTeamsInPromotionPlayOff(name, season),
                RelegationPlayoffTeams = await _seasonProcessingService.GetTeamsInRelegationPlayoff(name, season)
            };

            return Ok(response);
        }

        [HttpGet("{name}/{season}/promotion-system")]
        public async Task<ActionResult<PromotionSystemDto>> GetPromotionSystem(string name, string season)
        {
            var league = await _context.Leagues
                .Include(l => l.PromotionSystem)
                .FirstOrDefaultAsync(l => l.Name == name && l.Season == season);
            if (league == null) return NotFound(new { name, season });
            if (league.PromotionSystem == null)
                return BadRequest(new { error = "League does not have a promotion system", name, season });
            return Ok(new PromotionSystemDto(league.PromotionSystem));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<LeagueDto>> CreateLeague(LeagueDto leagueDto)
        {
            var newLeague = await _context.Leagues.AddAsync(leagueDto.Map());
            await _context.SaveChangesAsync();
            var returnObject = new { name = newLeague.Entity.Name, season = newLeague.Entity.Season };
            return Created(Url.Action("GetLeaguesByName", "Leagues", returnObject), new LeagueDto(newLeague.Entity));
        }

        [HttpPost("{name}/{season}/promotion-system")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<PromotionSystemDto>> ProvidePromotionSystem(
            string name,
            string season,
            [FromBody] PromotionSystemDto promotionSystemDto)
        {
            var league = await _context.Leagues
                .Include(l => l.PromotionSystem)
                .FirstOrDefaultAsync(l => l.Name == name && l.Season == season);
            if (league == null) return NotFound(new { name, season });
            _context.PromotionSystems.Remove(league.PromotionSystem);
            await _context.SaveChangesAsync();
            var promotionSystem = await _context.PromotionSystems.AddAsync(promotionSystemDto.Map());
            await _context.SaveChangesAsync();
            return Created(
                Url.Action("GetPromotionSystem", "Leagues", new { name, season }),
                new PromotionSystemDto(promotionSystem.Entity));
        }

        [HttpPost("{name}/{season}/simulate")]
        public async Task<ActionResult<ResultDto[]>> SimulateLeague(string name, string season)
        {
            var leagueFixtures = await _context.LeagueFixtures
                .Include(f => f.Events)
                .Include(f => f.League)
                .Include(f => f.HomeTeam)
                .Include(f => f.AwayTeam)
                .Where(f => f.LeagueName == name && f.Season == season)
                .ToListAsync();
            var results = new List<ResultDto>();
            foreach (var fixture in leagueFixtures.Where(fixture => !fixture.Events.Any()))
                results.Add(await GameFacilitator.StoreFixtureResult(fixture, _context));
            await _context.SaveChangesAsync();

            return Ok(results);
        }

        [HttpPost("{name}/{season}/simulate/override")]
        public async Task<ActionResult<List<ResultDto>>> OverrideLeagueSimulation(string name, string season)
        {
            var leagueFixtures = await _context.LeagueFixtures
                .Include(f => f.Events)
                .Include(f => f.League)
                .Include(f => f.HomeTeam)
                .Include(f => f.AwayTeam)
                .Where(f => f.LeagueName == name && f.Season == season)
                .ToListAsync();
            _context.LeagueFixtureEvents.RemoveRange(leagueFixtures.SelectMany(f => f.Events));
            await _context.SaveChangesAsync();
            var results = new List<ResultDto>();
            foreach (var fixture in leagueFixtures)
                results.Add(await GameFacilitator.StoreFixtureResult(fixture, _context));

            await _context.SaveChangesAsync();

            return Ok(results);
        }

        [HttpPost("{name}/{season}/simulate/{gameDay:int}/override")]
        public async Task<ActionResult<List<ResultDto>>> OverrideLeagueGameDaySimulation(string name, string season, int gameDay)
        {
            var leagueFixtures = await _context.LeagueFixtures
                .Include(f => f.Events)
                .Include(f => f.League)
                .Include(f => f.HomeTeam)
                .Include(f => f.AwayTeam)
                .Where(f => f.LeagueName == name && f.Season == season && f.GameDayNumber == gameDay)
                .ToListAsync();
            _context.LeagueFixtureEvents.RemoveRange(leagueFixtures.SelectMany(f => f.Events));
            await _context.SaveChangesAsync();
            var results = new List<ResultDto>();
            foreach (var fixture in leagueFixtures)
                results.Add(await GameFacilitator.StoreFixtureResult(fixture, _context));
            await _context.SaveChangesAsync();
            return Ok(results);
        }

        [HttpDelete("{name}/{season}/{gameDay:int}")]
        public async Task<ActionResult> DeleteLeagueGameDay(string name, string season, int gameDay)
        {
            var leagueFixtures = await _context.LeagueFixtures
                .Include(f => f.Events)
                .Where(f => f.LeagueName == name && f.Season == season && f.GameDayNumber == gameDay)
                .ToListAsync();
            _context.LeagueFixtureEvents.RemoveRange(leagueFixtures.SelectMany(f => f.Events));
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("gameplan/{name}/{season}/override")]
        public async Task<ActionResult> OverrideGamePlan(string name, string season)
        {
            var league = await _context.Leagues
                .Include(l => l.Teams)
                .Include(l => l.GameDays)
                .ThenInclude(gd => gd.Fixtures)
                .FirstOrDefaultAsync(l => l.Name == name && l.Season == season);
            if (league == null) return NotFound(new { name, season });
            if (league.GameDays.Any())
            {
                _context.LeagueGameDays.RemoveRange(league.GameDays);
                await _context.SaveChangesAsync();
            }

            var gameDays = MatchUpService.CreateRoundRobin(league.Teams.ToList(), league.Rounds);
            var gameDayNumber = 1;
            var leagueGameDays = new List<LeagueGameDay>();
            var leagueFixtures = new List<LeagueFixture>();
            foreach (var gameDay in gameDays)
            {
                leagueGameDays.Add(new LeagueGameDay
                {
                    LeagueName = league.Name,
                    Season = league.Season,
                    GameDayNumber = gameDayNumber
                });
                leagueFixtures.AddRange(gameDay.Games.Select(game => new LeagueFixture
                {
                    LeagueName = league.Name,
                    Season = league.Season,
                    GameDayNumber = gameDayNumber,
                    HomeTeamName = game.Home.Name,
                    AwayTeamName = game.Away.Name,
                    ShotAccuracyModifier = league.ShotAccuracyModifier,
                    PaceModifier = league.PaceModifier,
                    MaxHomeAdvantage = league.MaxHomeAdvantage,
                    MaxAwayDisadvantage = league.MaxAwayDisadvantage,
                    ActionsPerMinute = league.ActionsPerMinute,
                }));

                gameDayNumber++;
            }

            await _context.LeagueGameDays.AddRangeAsync(leagueGameDays);
            await _context.LeagueFixtures.AddRangeAsync(leagueFixtures);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{name}/{season}/{gameDay:int}/fixture")]
        public async Task<ActionResult> UpdateGameResult(
            string name,
            string season,
            int gameDay,
            [FromBody] LeagueGameUpdateRequest request)
        {
            try
            {
                var leagueGameDay = await _context.LeagueGameDays
                    .Include(lgd => lgd.Fixtures)
                    .ThenInclude(f => f.Events)
                    .FirstOrDefaultAsync(lgd => lgd.LeagueName == name &&
                                                lgd.Season == season &&
                                                lgd.GameDayNumber == gameDay);
                if (leagueGameDay == null)
                    return NotFound(new { Message = "Could not find game day", Ref = new { name, season, gameDay } });
                var game = leagueGameDay.Fixtures.FirstOrDefault(f => f.HomeTeamName == request.HomeTeamName &&
                                                                      f.AwayTeamName == request.AwayTeamName);
                if (game == null)
                    return NotFound(new
                    {
                        Message = "Could not find fixture",
                        Ref = new { name, season, gameDay, request.HomeTeamName, request.AwayTeamName }
                    });
                var goalEvents = game.Events.Where(e => e.IsGoal).ToList();
                var eventCount = goalEvents.Count.ToString();
                _context.LeagueFixtureEvents.RemoveRange(goalEvents);
                await _context.SaveChangesAsync();
                Log.Information(
                    "Removed all {@Events} goal events for game between {@HomeTeam} and {@AwayTeam}",
                    eventCount,
                    request.HomeTeamName,
                    request.AwayTeamName);
                var newEvents = request.HomeScoreEvents.Select(homeScoreEvent => new LeagueFixtureEvent
                    {
                        Season = season,
                        LeagueName = name,
                        IsGoal = true,
                        AddedMinute = homeScoreEvent.OvertimeMinute,
                        Minute = homeScoreEvent.Minute,
                        AwayTeamName = request.AwayTeamName,
                        HomeTeamName = request.HomeTeamName,
                        EventTeamName = request.HomeTeamName,
                        GameDayNumber = gameDay,
                        IsShotOnGoal = true
                    })
                    .ToList();
                newEvents.AddRange(request.AwayScoreEvents.Select(awayScoreEvent => new LeagueFixtureEvent
                {
                    Season = season,
                    LeagueName = name,
                    IsGoal = true,
                    AddedMinute = awayScoreEvent.OvertimeMinute,
                    Minute = awayScoreEvent.Minute,
                    AwayTeamName = request.AwayTeamName,
                    HomeTeamName = request.HomeTeamName,
                    EventTeamName = request.AwayTeamName,
                    GameDayNumber = gameDay,
                    IsShotOnGoal = true
                }));
                await _context.LeagueFixtureEvents.AddRangeAsync(newEvents);
                await _context.SaveChangesAsync();
                Log.Information("Added {@EventCount} events", newEvents.Count);
                Log.Debug("Added events:\r\n\t{@Events}", newEvents);
                return Ok();
            }
            catch (Exception exception)
            {
                Log.Error(exception, "An unhandled exception has occurred.\r\nRef: {@Request}", new
                {
                    name,
                    season,
                    gameDay,
                    request.HomeTeamName,
                    request.AwayTeamName
                });
                return BadRequest(new { Message = "We were unable to process your request." });
            }
        }

        [HttpPost("gameplan/{name}/{season}")]
        public async Task<ActionResult> CreateGamePlan(string name, string season)
        {
            var league = await _context.Leagues
                .Include(l => l.Teams)
                .Include(l => l.GameDays)
                .ThenInclude(gd => gd.Fixtures)
                .FirstOrDefaultAsync(l => l.Name == name && l.Season == season);
            if (league == null) return NotFound(new { name, season });
            if (league.GameDays.Any())
                return BadRequest(new BadRequestResponse
                {
                    Message =
                        $"Gameplan for league and season already created. Use {Url.Action("OverrideGamePlan", "Leagues", new { name, season })} instead.",
                    Object = new { name, season }
                });

            var gameDays = MatchUpService.CreateRoundRobin(league.Teams.ToList(), league.Rounds);
            var gameDayNumber = 1;
            var leagueGameDays = new List<LeagueGameDay>();
            var leagueFixtures = new List<LeagueFixture>();
            foreach (var gameDay in gameDays)
            {
                leagueGameDays.Add(new LeagueGameDay
                {
                    LeagueName = league.Name,
                    Season = league.Season,
                    GameDayNumber = gameDayNumber
                });
                leagueFixtures.AddRange(gameDay.Games.Select(game => new LeagueFixture
                {
                    LeagueName = league.Name,
                    Season = league.Season,
                    GameDayNumber = gameDayNumber,
                    HomeTeamName = game.Home.Name,
                    AwayTeamName = game.Away.Name,
                    ShotAccuracyModifier = league.ShotAccuracyModifier,
                    PaceModifier = league.PaceModifier,
                    MaxHomeAdvantage = league.MaxHomeAdvantage,
                    MaxAwayDisadvantage = league.MaxAwayDisadvantage,
                    ActionsPerMinute = league.ActionsPerMinute,
                }));

                gameDayNumber++;
            }

            await _context.LeagueGameDays.AddRangeAsync(leagueGameDays);
            await _context.LeagueFixtures.AddRangeAsync(leagueFixtures);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{name}/{season}")]
        public async Task<ActionResult<LeagueDto>> UpdateLeague(string name, string season, [FromBody] LeagueDto leagueDto)
        {
            var league = await _context.Leagues.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (league == null) return NotFound(new { name, season });
            leagueDto.MapUpdate(league);
            await _context.SaveChangesAsync();
            return Ok(new LeagueDto(league));
        }

        [HttpDelete("{name}/{season}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteLeague(string name, string season)
        {
            var league = await _context.Leagues
                .Include(l => l.Teams)
                .Include(l => l.LeagueFixtures)
                .Include(l => l.GameDays)
                .FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (league == null) return NotFound(new { name, season });
            _context.LeagueGameDays.RemoveRange(league.GameDays);
            _context.LeagueFixtures.RemoveRange(league.LeagueFixtures);
            _context.Teams.RemoveRange(league.Teams);
            _context.Leagues.Remove(league);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}