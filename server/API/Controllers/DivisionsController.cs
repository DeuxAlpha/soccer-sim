using System;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Dtos.Requests;
using API.Services;
using Database.Contexts;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DynamicQuerying.Main.Query.Models;
using DynamicQuerying.Main.Query.Services;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DivisionsController : ControllerBase
    {
        private readonly SoccerSimContext _context;
        private readonly SeasonProcessingService _seasonProcessingService;

        public DivisionsController(SoccerSimContext context, SeasonProcessingService seasonProcessingService)
        {
            _context = context;
            _seasonProcessingService = seasonProcessingService;
        }

        [HttpGet]
        [Obsolete($"Use OPTIONS:query:{nameof(GetDivisionOptions)}({nameof(QueryRequest)}) instead.")]
        public ActionResult<QueryResponse<DivisionDto>> GetDivisions([FromQuery] QueryRequest queryRequest)
        {
            return Ok(QueryService.GetQueryResponse(_context.Divisions.Select(d => new DivisionDto(d)), queryRequest));
        }
        
        [HttpOptions("query")]
        public ActionResult<QueryResponse<DivisionDto>> GetDivisionOptions([FromBody] QueryRequest queryRequest)
        {
            return Ok(QueryService.GetQueryResponse(_context.Divisions.Select(d => new DivisionDto(d)), queryRequest));
        }

        [HttpGet("countries/{country}/{season}")]
        public ActionResult<DivisionDto[]> GetDivisionsInCountry(string country, string season)
        {
            return Ok(_context.Divisions
                .Where(c => c.CountryName == country && c.Season == season)
                .Select(d => new DivisionDto(d)));
        }

        [HttpGet("{name}")]
        public ActionResult<DivisionDto[]> GetDivisionByName(string name)
        {
            return Ok(_context.Divisions.Where(d => d.Name == name).Select(d => new DivisionDto(d)));
        }

        [HttpGet("seasons/{season}")]
        public ActionResult<DivisionDto[]> GetDivisionBySeason(string season)
        {
            return Ok(_context.Divisions.Where(d => d.Season == season).Select(d => new DivisionDto(d)));
        }

        [HttpGet("{name}/{season}")]
        public async Task<ActionResult<DivisionDto>> GetDivision(string name, string season)
        {
            var division = await _context.Divisions.FirstOrDefaultAsync(d => d.Name == name && d.Season == season);
            if (division == null) return NotFound(new {name, season});
            return Ok(new DivisionDto(division));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<DivisionDto>> CreateDivision(DivisionDto divisionDto)
        {
            var newDivision = await _context.Divisions.AddAsync(divisionDto.Map());
            await _context.SaveChangesAsync();
            var returnObject = new {name = newDivision.Entity.Name, season = newDivision.Entity.Season};
            return Created(Url.Action("GetDivisionByName", "Divisions", returnObject), new DivisionDto(newDivision.Entity));
        }
        
        [HttpPost("{name}/{season}/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DivisionProcessingStatus>> GetDivisionProcessingStatus(string name, string season)
        {
            var division = await _context.Divisions.FirstOrDefaultAsync(d => d.Name == name && d.Season == season); // Sanity check to make sure the division exists
            if (division == null) return NotFound(new {name, season});
            var status = await _seasonProcessingService.GetDivisionProcessingStatus(season, name);
            return Ok(status);
        }

        [HttpPut("{name}/{season}")]
        public async Task<ActionResult<DivisionDto>> UpdateDivision(string name, string season, [FromBody] DivisionDto divisionDto)
        {
            var division = await _context.Divisions.FirstOrDefaultAsync(d => d.Name == name && d.Season == season);
            if (division == null) return NotFound(new {name, season});
            divisionDto.MapUpdate(division);
            await _context.SaveChangesAsync();
            return Ok(new DivisionDto(division));
        }

        [HttpDelete("{name}/{season}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteDivision(string name, string season)
        {
            var division = await _context.Divisions.FirstOrDefaultAsync(d => d.Name == name && d.Season == season);
            if (division == null) return NotFound(new {name, season});
            _context.Divisions.Remove(division);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}