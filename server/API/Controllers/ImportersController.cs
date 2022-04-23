using System;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Requests;
using Database.Contexts;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImportersController : ControllerBase
    {
        private readonly SoccerSimContext _soccerSimContext;

        public ImportersController(SoccerSimContext soccerSimContext)
        {
            _soccerSimContext = soccerSimContext;
        }

        // TODO: Cloning existing leagues
        
        [HttpPost]
        public async Task<IActionResult> ImportLeague([FromBody] ImportLeagueRequest request)
        {
            var results = request.Collection.ToList();
            if (!results.Any()) return BadRequest(new { Message = "No matchups found.", Ref = results});

            var alpha = results.First().Timestamp.Split("/").Last();
            if (alpha.Length > 2) alpha = alpha[2..];
            var omega = results.Last().Timestamp.Split("/").Last();
            if (omega.Length > 2) omega = omega[2..];
            var season = $"{alpha}-{omega}";
            
            var existingContinent =
                await _soccerSimContext.Continents
                    .FirstOrDefaultAsync(continent => continent.Name == request.Continent &&
                                                      continent.Season == season);
            if (existingContinent == null)
            {
                existingContinent = await CreateNewContinent(new Continent
                {
                    Name = request.Continent,
                    Season = season
                });
            }

            var existingCountry = await _soccerSimContext.Countries
                .FirstOrDefaultAsync(country => country.Name == request.Country &&
                                                country.Season == season);
            if (existingCountry == null)
                existingCountry = await CreateNewCountry(new Country
                {
                    Name = request.Country,
                    Abbreviation = request.Country[..3],
                    Season = season,
                    ContinentName = existingContinent.Name
                });

            var existingDivision = await _soccerSimContext.Divisions
                .FirstOrDefaultAsync(division => division.Name == request.Division &&
                                                 division.Season == season);
            if (existingDivision == null)
                existingDivision = await CreateNewDivision(new Division
                {
                    Name = request.Division,
                    Season = season,
                    CountryName = existingCountry.Name
                });

            var existingLeague = await _soccerSimContext.Leagues
                .FirstOrDefaultAsync(league => league.Name == request.League &&
                                               league.Season == season);
            if (existingLeague == null)
                existingLeague = await CreateNewLeague(new League
                {
                    Name = request.League,
                    Season = season,
                    DivisionName = existingDivision.Name
                });

            // Let's first create all the teams.
            var clubsInResults = results.Select(result => result.HomeTeamName).Distinct().ToList();

            var clubsCount = clubsInResults.Count;
            foreach (var club in clubsInResults)
            {
                var existingTeam = await _soccerSimContext.Teams
                    .FirstOrDefaultAsync(team => team.Name == club &&
                                                 team.Season == season);
                if (existingTeam == null)
                    await CreateNewTeam(new Team
                    {
                        Abbreviation = club[..3],
                        Name = club,
                        Season = season,
                        LeagueName = existingLeague.Name
                    });
            }

            for (var matchDay = 1; matchDay <= (clubsCount - 1) * 2; matchDay++)
            {
                var existingMatchDay = await _soccerSimContext.LeagueGameDays
                    .FirstOrDefaultAsync(gameDay => gameDay.LeagueName == existingLeague.Name &&
                                                    gameDay.Season == season &&
                                                    gameDay.GameDayNumber == matchDay);
                if (existingMatchDay == null)
                    await CreateNewGameDay(new LeagueGameDay
                    {
                        LeagueName = existingLeague.Name,
                        Season = season,
                        GameDayNumber = matchDay
                    });
            }

            var currentMatchDay = 1;
            var resultsPerMatchDay = clubsCount / 2;

            await PrunePreExistingEvents(existingLeague.Name, season);
            for (var resultIndex = 0; resultIndex < results.Count; resultIndex++)
            {
                if (resultIndex != 0 && resultIndex % resultsPerMatchDay == 0) currentMatchDay++;
                var result = results[resultIndex];
                var fixture = new LeagueFixture
                {
                    // TODO: Fix missing game day property
                    GameDayNumber = currentMatchDay,
                    Season = season,
                    LeagueName = existingLeague.Name,
                    HomeTeamName = result.HomeTeamName,
                    AwayTeamName = result.AwayTeamName
                };
                var existingFixture = await _soccerSimContext.LeagueFixtures
                    .FirstOrDefaultAsync(leagueFixture => leagueFixture.Season == season &&
                                                    leagueFixture.LeagueName == existingLeague.Name &&
                                                    leagueFixture.GameDayNumber == currentMatchDay &&
                                                    leagueFixture.HomeTeamName == result.HomeTeamName &&
                                                    leagueFixture.AwayTeamName == result.AwayTeamName);
                if (existingFixture == null)
                    await CreateNewFixture(fixture);
                var rand = new Random();
                
                // Prune all preexisting events
                // var preExistingEvents = await _soccerSimContext.LeagueFixtureEvents
                    // .Where(fixtureEvent => fixtureEvent.LeagueName == existingLeague.Name &&
                                           // fixtureEvent.Season == season &&
                                           // fixtureEvent.GameDayNumber == currentMatchDay &&
                                           // fixtureEvent.HomeTeamName == result.HomeTeamName &&
                                           // fixtureEvent.AwayTeamName == result.AwayTeamName)
                    // .ToListAsync();
                // _soccerSimContext.LeagueFixtureEvents.RemoveRange(preExistingEvents);
                // await _soccerSimContext.SaveChangesAsync();

                for (var scoredGoals = 0; scoredGoals < result.HomeHalfTimeGoals; scoredGoals++)
                {
                    await CreateNewFixtureEvent(new LeagueFixtureEvent
                    {
                        Minute = rand.Next(0, 45),
                        Season = season,
                        IsGoal = true,
                        AddedMinute = 0,
                        GameDayNumber = currentMatchDay,
                        LeagueName = existingLeague.Name,
                        EventTeamName = result.HomeTeamName,
                        HomeTeamName = result.HomeTeamName,
                        AwayTeamName = result.AwayTeamName
                    });
                }

                for (var scoredGoals = 0; scoredGoals < result.AwayHalfTimeGoals; scoredGoals++)
                {
                    await CreateNewFixtureEvent(new LeagueFixtureEvent
                    {
                        Minute = rand.Next(0, 45),
                        Season = season,
                        IsGoal = true,
                        AddedMinute = 0,
                        GameDayNumber = currentMatchDay,
                        LeagueName = existingLeague.Name,
                        EventTeamName = result.AwayTeamName,
                        HomeTeamName = result.HomeTeamName,
                        AwayTeamName = result.AwayTeamName
                    });
                }

                for (var scoredGoals = result.HomeHalfTimeGoals; scoredGoals < result.HomeFullTimeGoals; scoredGoals++)
                {
                    await CreateNewFixtureEvent(new LeagueFixtureEvent
                    {
                        Minute = rand.Next(45, 90),
                        Season = season,
                        IsGoal = true,
                        AddedMinute = 0,
                        GameDayNumber = currentMatchDay,
                        LeagueName = existingLeague.Name,
                        EventTeamName = result.HomeTeamName,
                        HomeTeamName = result.HomeTeamName,
                        AwayTeamName = result.AwayTeamName
                    });
                }

                for (var scoredGoals = result.AwayHalfTimeGoals; scoredGoals < result.AwayFullTimeGoals; scoredGoals++)
                {
                    await CreateNewFixtureEvent(new LeagueFixtureEvent
                    {
                        Minute = rand.Next(45, 90),
                        Season = season,
                        IsGoal = true,
                        AddedMinute = 0,
                        GameDayNumber = currentMatchDay,
                        LeagueName = existingLeague.Name,
                        EventTeamName = result.AwayTeamName,
                        HomeTeamName = result.HomeTeamName,
                        AwayTeamName = result.AwayTeamName
                    });
                }
            }

            return Ok();
        }

        private async Task PrunePreExistingEvents(string leagueName, string season)
        {
            var preExistingEvents = await _soccerSimContext.LeagueFixtureEvents
                .Where(fixtureEvent => fixtureEvent.LeagueName == leagueName &&
                                       fixtureEvent.Season == season)
                .ToListAsync();
            _soccerSimContext.LeagueFixtureEvents.RemoveRange(preExistingEvents);
            await _soccerSimContext.SaveChangesAsync();
        }


        private async Task<LeagueFixtureEvent> CreateNewFixtureEvent(LeagueFixtureEvent fixtureEvent)
        {
            async Task<LeagueFixtureEvent> RetryThisEvent()
            {
                fixtureEvent.Minute -= 1;
                return await CreateNewFixtureEvent(fixtureEvent);
            }

            try
            {
                var addedEvent = await _soccerSimContext.LeagueFixtureEvents.AddAsync(fixtureEvent);
                await _soccerSimContext.SaveChangesAsync();
                return addedEvent.Entity;
            }
            catch (InvalidOperationException invalidOperationException)
            {
                Log.Warning(invalidOperationException, "Exception occurred. Reducing Minute and retrying");
                return await RetryThisEvent();
            }
            catch (SqlException sqlException)
            {
                Log.Warning(sqlException, "Exception occurred. Reducing minute and retrying");
                return await RetryThisEvent();
            }
            catch (DbUpdateException dbUpdateException)
            {
                Log.Warning(dbUpdateException, "Exception occurred. Reducing minute and retrying");
                return await RetryThisEvent();
            }
        }

        private async Task<LeagueFixture> CreateNewFixture(LeagueFixture fixture)
        {
            var addedFixture = await _soccerSimContext.LeagueFixtures.AddAsync(fixture);
            await _soccerSimContext.SaveChangesAsync();
            return addedFixture.Entity;
        }

        private async Task<LeagueGameDay> CreateNewGameDay(LeagueGameDay leagueGameDay)
        {
            var addedGameDay = await _soccerSimContext.LeagueGameDays.AddAsync(leagueGameDay);
            await _soccerSimContext.SaveChangesAsync();
            return addedGameDay.Entity;
        }

        private async Task<Team> CreateNewTeam(Team team)
        {
            var addedTeam = await _soccerSimContext.Teams.AddAsync(team);
            await _soccerSimContext.SaveChangesAsync();
            return addedTeam.Entity;
        }

        private async Task<Division> CreateNewDivision(Division division)
        {
            var addedDivision = await _soccerSimContext.Divisions.AddAsync(division);
            await _soccerSimContext.SaveChangesAsync();
            return addedDivision.Entity;
        }

        private async Task<League> CreateNewLeague(League league)
        {
            var addedLeague = await _soccerSimContext.Leagues.AddAsync(league);
            await _soccerSimContext.SaveChangesAsync();
            return addedLeague.Entity;
        }

        private async Task<Continent> CreateNewContinent(Continent continent)
        {
            var addedContinent = await _soccerSimContext.Continents.AddAsync(continent);
            await _soccerSimContext.SaveChangesAsync();
            return addedContinent.Entity;
        }

        private async Task<Country> CreateNewCountry(Country country)
        {
            var addedCountry = await _soccerSimContext.Countries.AddAsync(country);
            await _soccerSimContext.SaveChangesAsync();
            return addedCountry.Entity;
        }
    }
}