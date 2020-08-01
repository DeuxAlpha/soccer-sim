using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Dtos.Responses;
using API.Dtos.Views;
using API.Dtos.Views.Table;
using API.Services;
using Database.Contexts;
using Database.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Querying.Query.Models;
using Querying.Query.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaguesController : ControllerBase
    {
        private readonly SoccerSimContext _context;

        public LeaguesController(SoccerSimContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetLeagues([FromQuery] QueryRequest queryRequest)
        {
            return Ok(QueryService.GetQueryResponse(_context.Leagues.Select(c => new LeagueDto(c)), queryRequest));
        }

        [HttpGet("divisions/{division}/{season}")]
        public IActionResult GetLeaguesInDivision(string division, string season)
        {
            return Ok(_context.Leagues
                .Where(l => l.DivisionName == division && l.Season == season)
                .Select(l => new LeagueDto(l)));
        }

        [HttpGet("{name}")]
        public IActionResult GetLeague(string name)
        {
            return Ok(_context.Leagues.Where(c => c.Name == name).Select(c => new LeagueDto(c)));
        }

        [HttpGet("seasons/{season}")]
        public IActionResult GetLeagues(string season)
        {
            return Ok(_context.Leagues.Where(c => c.Season == season).Select(c => new LeagueDto(c)));
        }

        [HttpGet("{name}/{season}")]
        public async Task<IActionResult> GetLeague(string name, string season)
        {
            var country = await _context.Leagues.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (country == null) return NotFound(new {name, season});
            return Ok(new LeagueDto(country));
        }

        [HttpGet("{name}/{season}/fixtures/{gameDay}")]
        public async Task<IActionResult> GetLeagueFixture(string name, string season, int gameDay)
        {
            var fixtures = await _context.LeagueFixtures
                .Include(f => f.Events)
                .Where(gd => gd.LeagueName == name && gd.Season == season && gd.GameDayNumber == gameDay)
                .ToListAsync();
            var results = fixtures.Select(fixture => new ResultDto(fixture)).ToList();

            return Ok(results);
        }

        [HttpGet("{name}/{season}/table")]
        public async Task<IActionResult> GetLeagueTable(string name, string season)
        {
            // TODO: Get previous table position
            var league = await _context.Leagues
                .Include(l => l.Teams)
                .FirstOrDefaultAsync(l => l.Name == name && l.Season == season);
            if (league == null) return NotFound(new {name, season});
            var teams = league.Teams.ToList();
            var table = new TableDto
            {
                // Need to be done thrice because each need to be different tables.
                Positions = teams.Select(t => new TablePositionDto
                {
                    TeamName = t.Name
                }).ToList(),
                HomePositions = teams.Select(t => new TablePositionDto
                {
                    TeamName = t.Name
                }).ToList(),
                AwayPositions = teams.Select(t => new TablePositionDto
                {
                    TeamName = t.Name
                }).ToList()
            };
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

            return Ok(table);
        }

        [HttpGet("{name}/{season}/table/{gameDay}")]
        public async Task<IActionResult> GetLeagueTable(string name, string season, int gameDay)
        {
            var league = await _context.Leagues
                .Include(l => l.Teams)
                .FirstOrDefaultAsync(l => l.Name == name && l.Season == season);
            if (league == null) return NotFound(new {name, season});
            var teams = league.Teams.ToList();
            var table = new TableDto
            {
                // Need to be done thrice because each need to be different tables.
                Positions = teams.Select(t => new TablePositionDto
                {
                    TeamName = t.Name
                }).ToList(),
                HomePositions = teams.Select(t => new TablePositionDto
                {
                    TeamName = t.Name
                }).ToList(),
                AwayPositions = teams.Select(t => new TablePositionDto
                {
                    TeamName = t.Name
                }).ToList()
            };
            var fixtures = await _context.LeagueFixtures
                .Include(f => f.Events)
                .Include(f => f.HomeTeam)
                .Include(f => f.AwayTeam)
                .Where(f => f.LeagueName == name && f.Season == season && f.GameDayNumber == gameDay)
                .ToListAsync();
            foreach (var fixture in fixtures)
            {
                table.AddFixture(new ResultDto(fixture));
            }
            table.ApplyPositions();

            return Ok(table);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeague(LeagueDto leagueDto)
        {
            var newLeague = await _context.Leagues.AddAsync(leagueDto.Map());
            await _context.SaveChangesAsync();
            var returnObject = new {name = newLeague.Entity.Name, season = newLeague.Entity.Season};
            return Created(Url.Action("GetLeague", "Leagues", returnObject), new LeagueDto(newLeague.Entity));
        }

        [HttpPost("{name}/{season}/simulate")]
        public async Task<IActionResult> SimulateLeague(string name, string season)
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
        public async Task<IActionResult> OverrideLeagueSimulation(string name, string season)
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

        [HttpPost("gameplan/{name}/{season}/override")]
        public async Task<IActionResult> OverrideGamePlan(string name, string season)
        {
            var league = await _context.Leagues
                .Include(l => l.Teams)
                .Include(l => l.GameDays)
                .ThenInclude(gd => gd.Fixtures)
                .FirstOrDefaultAsync(l => l.Name == name && l.Season == season);
            if (league == null) return NotFound(new {name, season});
            if (league.GameDays.Any())
            {
                _context.LeagueGameDays.RemoveRange(league.GameDays);
                await _context.SaveChangesAsync();
            }

            var gameDays = MatchUpService.CreateRoundRobin(league.Teams.ToList(), true);
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

        [HttpPost("gameplan/{name}/{season}")]
        public async Task<IActionResult> CreateGamePlan(string name, string season)
        {
            var league = await _context.Leagues
                .Include(l => l.Teams)
                .Include(l => l.GameDays)
                .ThenInclude(gd => gd.Fixtures)
                .FirstOrDefaultAsync(l => l.Name == name && l.Season == season);
            if (league == null) return NotFound(new {name, season});
            if (league.GameDays.Any())
                return BadRequest(new BadRequestResponse
                {
                    Message = $"Gameplan for league and season already created. Use {Url.Action("OverrideGamePlan", "Leagues", new {name, season})} instead.",
                    Object = new {name, season}
                });

            var gameDays = MatchUpService.CreateRoundRobin(league.Teams.ToList(), true);
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
        public async Task<IActionResult> UpdateLeague(string name, string season, [FromBody] LeagueDto leagueDto)
        {
            var league = await _context.Leagues.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (league == null) return NotFound(new {name, season});
            leagueDto.MapUpdate(league);
            await _context.SaveChangesAsync();
            return Ok(new LeagueDto(league));
        }

        [HttpDelete("{name}/{season}")]
        public async Task<IActionResult> DeleteLeague(string name, string season)
        {
            var league = await _context.Countries.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (league == null) return NotFound(new {name, season});
            _context.Countries.Remove(league);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}