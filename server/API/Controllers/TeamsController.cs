using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using Database.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Querying.Query.Models;
using Querying.Query.Services;

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
        public IActionResult GetTeams(QueryRequest request)
        {
            return Ok(QueryService.GetQueryResponse(_context.Teams.Select(t => new TeamDto(t)), request));
        }

        [HttpGet("{name}")]
        public IActionResult GetTeam(string name)
        {
            return Ok(_context.Teams.Where(c => c.Name == name).Select(c => new TeamDto(c)));
        }

        [HttpGet("seasons/{season}")]
        public IActionResult GetTeams(string season)
        {
            return Ok(_context.Teams.Where(c => c.Season == season).Select(c => new TeamDto(c)));
        }

        [HttpGet("{name}/{season}")]
        public async Task<IActionResult> GetTeam(string name, string season)
        {
            var country = await _context.Teams.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (country == null) return NotFound(new {name, season});
            return Ok(new TeamDto(country));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(TeamDto teamDto)
        {
            var newTeam = await _context.Teams.AddAsync(teamDto.Map());
            await _context.SaveChangesAsync();
            var returnObject = new {name = newTeam.Entity.Name, season = newTeam.Entity.Season};
            return Created(Url.Action("GetTeam", "Teams", returnObject), new TeamDto(newTeam.Entity));
        }

        [HttpPut("{name}/{season}")]
        public async Task<IActionResult> UpdateTeam(string name, string season, [FromBody] TeamDto teamDto)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (team == null) return NotFound(new {name, season});
            teamDto.MapUpdate(team);
            await _context.SaveChangesAsync();
            return Ok(new TeamDto(team));
        }

        [HttpDelete("{name}/{season}")]
        public async Task<IActionResult> DeleteTeam(string name, string season)
        {
            var team = await _context.Countries.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (team == null) return NotFound(new {name, season});
            _context.Countries.Remove(team);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}