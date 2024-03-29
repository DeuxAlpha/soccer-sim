﻿using System;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using Database.Contexts;
using DynamicQuerying.Main.Query.Models;
using DynamicQuerying.Main.Query.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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
        [Obsolete($"Use OPTIONS:query:{nameof(GetContinentOptions)}({nameof(QueryRequest)}) instead.")]
        public ActionResult<QueryResponse<ContinentDto>> GetContinents([FromQuery] QueryRequest queryRequest)
        {
            return Ok(QueryService.GetQueryResponse(_context.Continents.Select(c => new ContinentDto(c)),
                queryRequest));
        }
        
        [HttpOptions("query")]
        public ActionResult<QueryResponse<ContinentDto>> GetContinentOptions([FromBody] QueryRequest queryRequest)
        {
            return Ok(QueryService.GetQueryResponse(_context.Continents.Select(c => new ContinentDto(c)),
                queryRequest));
        }

        [HttpGet("seasons")]
        public async Task<ActionResult<string[]>> GetSeasons()
        {
            return Ok(await _context.Continents.Select(c => c.Season).Distinct().ToListAsync());
        }

        [HttpGet("{name}")]
        public ActionResult<ContinentDto> GetContinent(string name)
        {
            return Ok(_context.Continents.Where(c => c.Name == name).Select(c => new ContinentDto(c)));
        }

        [HttpGet("seasons/{season}")]
        public ActionResult<ContinentDto[]> GetContinents(string season)
        {
            return Ok(_context.Continents.Where(c => c.Season == season).Select(c => new ContinentDto(c)));
        }

        [HttpGet("{name}/{season}")]
        public async Task<ActionResult<ContinentDto>> GetContinent(string name, string season)
        {
            var continent = await _context.Continents.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (continent == null) return NotFound(new {name, season});
            return Ok(new ContinentDto(continent));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ContinentDto>> CreateContinent(ContinentDto continentDto)
        {
            var newContinent = await _context.Continents.AddAsync(continentDto.Map());
            await _context.SaveChangesAsync();
            var returnObject = new {name = newContinent.Entity.Name, season = newContinent.Entity.Season};
            return Created(Url.Action("GetContinent", "Continents", returnObject),
                new ContinentDto(newContinent.Entity));
        }

        [HttpDelete("{name}/{season}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteContinent(string name, string season)
        {
            var continent = await _context.Continents.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (continent == null) return NotFound(new {name, season});
            _context.Continents.Remove(continent);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}