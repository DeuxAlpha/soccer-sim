using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Dtos.Views;
using API.Services;
using Database.Contexts;
using Database.Models;
using Domain.Enums;
using Domain.Models;
using Domain.Services;
using DynamicQuerying.Main.Query.Models;
using DynamicQuerying.Main.Query.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly SoccerSimContext _context;

        public TeamsController(SoccerSimContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Obsolete($"Use OPTIONS:query:{nameof(GetTeamOptions)}({nameof(QueryRequest)}) instead.")]
        public ActionResult<QueryResponse<TeamDto>> GetTeams([FromQuery] QueryRequest request)
        {
            return Ok(QueryService.GetQueryResponse(_context.Teams.Select(t => new TeamDto(t)), request));
        }
        
        [HttpOptions("query")]
        public ActionResult<QueryResponse<TeamDto>> GetTeamOptions([FromBody] QueryRequest request)
        {
            return Ok(QueryService.GetQueryResponse(_context.Teams.Select(t => new TeamDto(t)), request));
        }

        [HttpGet("{name}")]
        public ActionResult<TeamDto[]> GetTeam(string name)
        {
            return Ok(_context.Teams.Where(c => c.Name == name).Select(c => new TeamDto(c)));
        }

        [HttpGet("seasons/{season}")]
        public ActionResult<TeamDto[]> GetTeams(string season)
        {
            return Ok(_context.Teams.Where(c => c.Season == season).Select(c => new TeamDto(c)));
        }

        [HttpGet("{name}/{season}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TeamDto>> GetTeam(string name, string season)
        {
            var country = await _context.Teams.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (country == null) return NotFound(new {name, season});
            return Ok(new TeamDto(country));
        }

        [HttpGet("{name}/{season}/fixtures")]
        public ActionResult<LeagueFixtureDto[]> GetTeamFixtures(string name, string season)
        {
            return Ok(_context.LeagueFixtures
                .Include(f => f.Events)
                .Where(f => (f.HomeTeamName == name || f.AwayTeamName == name) && f.Season == season)
                .Select(f => new LeagueFixtureDto(f)));
        }

        [HttpGet("{name}/{season}/{league}/fixtures")]
        public ActionResult<LeagueFixtureDto[]> GetTeamFixtures(string name, string season, string league)
        {
            return Ok(_context.LeagueFixtures
                .Include(f => f.Events)
                .Where(f =>
                    (f.HomeTeamName == name || f.AwayTeamName == name) &&
                    f.Season == season &&
                    f.LeagueName == league)
                .Select(f => new LeagueFixtureDto(f)));
        }

        [HttpGet("{name}/{season}/{league}/{gameDay}")]
        public async Task<ActionResult<LeagueFixtureDto>> GetTeamFixture(string name, string season, string league, int gameDay)
        {
            var fixture = await _context.LeagueFixtures
                .Include(f => f.Events)
                .FirstOrDefaultAsync(f =>
                    (f.HomeTeamName == name || f.AwayTeamName == name) &&
                    f.Season == season &&
                    f.LeagueName == league &&
                    f.GameDayNumber == gameDay);
            if (fixture == null) return NotFound(new {name, season, league, gameDay});
            return Ok(new LeagueFixtureDto(fixture));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TeamDto>> CreateTeam(TeamDto teamDto)
        {
            var newTeam = await _context.Teams.AddAsync(teamDto.Map());
            await _context.SaveChangesAsync();
            var returnObject = new {name = newTeam.Entity.Name, season = newTeam.Entity.Season};
            return Created(Url.Action("GetTeam", "Teams", returnObject), new TeamDto(newTeam.Entity));
        }

        [HttpPost("{name}/{season}/simulate")]
        public async Task<ActionResult<ResultDto[]>> SimulateTeamFixtures(string name, string season)
        {
            var leagueFixtures = await _context.LeagueFixtures
                .Include(f => f.Events)
                .Include(f => f.League)
                .Include(f => f.HomeTeam)
                .Include(f => f.AwayTeam)
                .Where(f =>
                    (f.HomeTeamName == name || f.AwayTeamName == name) &&
                    f.Season == season)
                .ToListAsync();
            var results = new List<ResultDto>();
            foreach (var fixture in leagueFixtures.Where(fixture => !fixture.Events.Any()))
                results.Add(await GameFacilitator.StoreFixtureResult(fixture, _context));
            await _context.SaveChangesAsync();

            return Ok(results);
        }

        [HttpPost("{name}/{season}/simulate/{gameDay:int}")]
        public async Task<ActionResult<ResultDto>> SimulateTeamFixture(string name, string season, int gameDay)
        {
            var leagueFixture = await _context.LeagueFixtures
                .Include(f => f.Events)
                .Include(f => f.League)
                .Include(f => f.HomeTeam)
                .Include(f => f.AwayTeam)
                .Where(f => (f.HomeTeamName == name || f.AwayTeamName == name) &&
                            f.Season == season &&
                            f.GameDayNumber == gameDay)
                .FirstOrDefaultAsync();
            _context.LeagueFixtureEvents.RemoveRange(leagueFixture.Events);
            await _context.SaveChangesAsync();
            var result = await GameFacilitator.StoreFixtureResult(leagueFixture, _context);
            await _context.SaveChangesAsync();
            return Ok(result);
        }
        

        [HttpPost("{name}/{season}/simulate/override")]
        public async Task<ActionResult<ResultDto>> OverrideTeamFixtureSimulations(string name, string season)
        {
            var leagueFixtures = await _context.LeagueFixtures
                .Include(f => f.Events)
                .Include(f => f.League)
                .Include(f => f.HomeTeam)
                .Include(f => f.AwayTeam)
                .Where(f =>
                    (f.HomeTeamName == name || f.AwayTeamName == name) &&
                    f.Season == season)
                .ToListAsync();
            _context.LeagueFixtureEvents.RemoveRange(leagueFixtures.SelectMany(f => f.Events));
            await _context.SaveChangesAsync();
            var results = new List<ResultDto>();
            foreach (var fixture in leagueFixtures)
                results.Add(await GameFacilitator.StoreFixtureResult(fixture, _context));

            await _context.SaveChangesAsync();

            return Ok(results);
        }

        [HttpPut("{name}/{season}/strengths/{strength:double}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TeamDto>> UpdateTeamStrengths(
            string name,
            string season,
            double strength)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(t => t.Name == name &&
                                                                     t.Season == season);
            if (team == null) return NotFound(new { Message = "Could not find team.", Ref = new { name, season } });
            team.AttackStrength = strength;
            team.DefenseStrength = strength;
            team.GoalieStrength = strength;
            await _context.SaveChangesAsync();
            return Ok(new TeamDto(team));
        }

        [HttpPut("{name}/{season}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TeamDto>> UpdateTeam(string name, string season, [FromBody] TeamDto teamDto)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (team == null) return NotFound(new {name, season});
            teamDto.MapUpdate(team);
            await _context.SaveChangesAsync();
            return Ok(new TeamDto(team));
        }

        [HttpDelete("{name}/{season}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteTeam(string name, string season)
        {
            var team = await _context.Countries.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (team == null) return NotFound(new {name, season});
            _context.Countries.Remove(team);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}