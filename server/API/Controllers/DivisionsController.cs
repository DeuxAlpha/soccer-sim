﻿using System.Linq;
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
    public class DivisionsController : ControllerBase
    {
        private readonly SoccerSimContext _context;

        public DivisionsController(SoccerSimContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDivisions(QueryRequest queryRequest)
        {
            return Ok(QueryService.GetQueryResponse(_context.Divisions.Select(d => new DivisionDto(d)), queryRequest));
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