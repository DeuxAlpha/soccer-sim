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
            if (country == null) return NotFound(new {Name = name, Season = season});
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

        [HttpPut("{name}/{season}")]
        public async Task<IActionResult> UpdateLeague(string name, string season, [FromBody] LeagueDto leagueDto)
        {
            var league = await _context.Leagues.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (league == null) return NotFound(new {Name = name, Season = season});
            leagueDto.MapUpdate(league);
            await _context.SaveChangesAsync();
            return Ok(new LeagueDto(league));
        }

        [HttpDelete("{name}/{season}")]
        public async Task<IActionResult> DeleteLeague(string name, string season)
        {
            var league = await _context.Countries.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (league == null) return NotFound(new {Name = name, Season = season});
            _context.Countries.Remove(league);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}