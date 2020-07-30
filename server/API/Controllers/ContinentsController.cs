
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
    public class ContinentsController : ControllerBase
    {
        private readonly SoccerSimContext _context;

        public ContinentsController(SoccerSimContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetContinents(QueryRequest queryRequest)
        {
            return Ok(QueryService.GetQueryResponse(_context.Continents.Select(c => new ContinentDto(c)),
                queryRequest));
        }

        [HttpGet("{name}")]
        public IActionResult GetContinent(string name)
        {
            return Ok(_context.Continents.Where(c => c.Name == name).Select(c => new ContinentDto(c)));
        }

        [HttpGet("seasons/{season}")]
        public IActionResult GetContinents(string season)
        {
            return Ok(_context.Continents.Where(c => c.Season == season).Select(c => new ContinentDto(c)));
        }

        [HttpGet("{name}/{season}")]
        public async Task<IActionResult> GetContinent(string name, string season)
        {
            var continent = await _context.Continents.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (continent == null) return NotFound(new {name, season});
            return Ok(new ContinentDto(continent));
        }

        [HttpPost]
        public async Task<IActionResult> CreateContinent(ContinentDto continentDto)
        {
            var newContinent = await _context.Continents.AddAsync(continentDto.Map());
            await _context.SaveChangesAsync();
            var returnObject = new {name = newContinent.Entity.Name, season = newContinent.Entity.Season};
            return Created(Url.Action("GetContinent", "Continents", returnObject),
                new ContinentDto(newContinent.Entity));
        }

        [HttpDelete("{name}/{season}")]
        public async Task<IActionResult> DeleteContinent(string name, string season)
        {
            var continent = await _context.Continents.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (continent == null) return NotFound(new {name, season});
            _context.Continents.Remove(continent);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}