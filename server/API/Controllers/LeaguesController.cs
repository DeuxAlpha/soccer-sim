using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
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
        public IActionResult GetLeagues(QueryRequest queryRequest)
        {
            return Ok(QueryService.GetQueryResponse(_context.Leagues.Select(c => new LeagueDto(c)), queryRequest));
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

        [HttpPost]
        public async Task<IActionResult> CreateLeague(LeagueDto leagueDto)
        {
            var newLeague = await _context.Leagues.AddAsync(leagueDto.Map());
            await _context.SaveChangesAsync();
            var returnObject = new {name = newLeague.Entity.Name, season = newLeague.Entity.Season};
            return Created(Url.Action("GetLeague", "Leagues", returnObject), new LeagueDto(newLeague.Entity));
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
            {
                _context.LeagueFixtures.RemoveRange(league.GameDays.SelectMany(gd => gd.Fixtures));
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
                    AwayTeamName = game.Away.Name
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