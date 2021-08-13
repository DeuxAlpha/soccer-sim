using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using Database.Contexts;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BISSELL.Querying.Query.Models;
using BISSELL.Querying.Query.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DivisionsController : ControllerBase
    {
        private readonly SoccerSimContext _context;

        public DivisionsController(SoccerSimContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDivisions([FromQuery] QueryRequest queryRequest)
        {
            return Ok(QueryService.GetQueryResponse(_context.Divisions.Select(d => new DivisionDto(d)), queryRequest));
        }

        [HttpGet("countries/{country}/{season}")]
        public IActionResult GetDivisionsInCountry(string country, string season)
        {
            return Ok(_context.Divisions
                .Where(c => c.CountryName == country && c.Season == season)
                .Select(d => new DivisionDto(d)));
        }

        [HttpGet("{name}")]
        public IActionResult GetDivision(string name)
        {
            return Ok(_context.Divisions.Where(d => d.Name == name).Select(d => new DivisionDto(d)));
        }

        [HttpGet("seasons/{season}")]
        public IActionResult GetDivisions(string season)
        {
            return Ok(_context.Divisions.Where(d => d.Season == season).Select(d => new DivisionDto(d)));
        }

        [HttpGet("{name}/{season}")]
        public async Task<IActionResult> GetDivision(string name, string season)
        {
            var division = await _context.Divisions.FirstOrDefaultAsync(d => d.Name == name && d.Season == season);
            if (division == null) return NotFound(new {name, season});
            return Ok(new DivisionDto(division));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDivision(DivisionDto divisionDto)
        {
            var newDivision = await _context.Divisions.AddAsync(divisionDto.Map());
            await _context.SaveChangesAsync();
            var returnObject = new {name = newDivision.Entity.Name, season = newDivision.Entity.Season};
            return Created(Url.Action("GetDivision", "Divisions", returnObject), new DivisionDto(newDivision.Entity));
        }

        [HttpPut("{name}/{season}")]
        public async Task<IActionResult> UpdateDivision(string name, string season, [FromBody] DivisionDto divisionDto)
        {
            var division = await _context.Divisions.FirstOrDefaultAsync(d => d.Name == name && d.Season == season);
            if (division == null) return NotFound(new {name, season});
            divisionDto.MapUpdate(division);
            await _context.SaveChangesAsync();
            return Ok(new DivisionDto(division));
        }

        [HttpDelete("{name}/{season}")]
        public async Task<IActionResult> DeleteDivision(string name, string season)
        {
            var division = await _context.Divisions.FirstOrDefaultAsync(d => d.Name == name && d.Season == season);
            if (division == null) return NotFound(new {name, season});
            _context.Divisions.Remove(division);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}