﻿using System;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using Database.Contexts;
using Database.Models;
using DynamicQuerying.Main.Query.Models;
using DynamicQuerying.Main.Query.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly SoccerSimContext _context;

        public CountriesController(SoccerSimContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Obsolete("Use OPTIONS:query:{nameof(GetCountryOptions)}({nameof(QueryRequest)}) instead.")]
        public ActionResult<QueryResponse<CountryDto>> GetCountries([FromQuery] QueryRequest queryRequest)
        {
            return Ok(QueryService.GetQueryResponse(_context.Countries.Select(c => new CountryDto(c)), queryRequest));
        }
        
        [HttpOptions("query")]
        public ActionResult<QueryResponse<CountryDto>> GetCountryOptions([FromBody] QueryRequest queryRequest)
        {
            return Ok(QueryService.GetQueryResponse(_context.Countries.Select(c => new CountryDto(c)), queryRequest));
        }

        [HttpGet("continents/{continent}/{season}")]
        public ActionResult<CountryDto[]> GetCountriesOnContinent(string continent, string season)
        {
            return Ok(_context.Countries
                .Where(c => c.ContinentName == continent && c.Season == season)
                .Select(c => new CountryDto(c)));
        }

        [HttpGet("{name}")]
        public ActionResult<CountryDto> GetCountry(string name)
        {
            return Ok(_context.Countries.Where(c => c.Name == name).Select(c => new CountryDto(c)));
        }

        [HttpGet("seasons/{season}")]
        public ActionResult<CountryDto[]> GetCountries(string season)
        {
            return Ok(_context.Countries.Where(c => c.Season == season).Select(c => new CountryDto(c)));
        }

        [HttpGet("{name}/{season}")]
        public async Task<IActionResult> GetCountry(string name, string season)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (country == null) return NotFound(new {name, season});
            return Ok(new CountryDto(country));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateCountry(CountryDto countryDto)
        {
            var newCountry = await _context.Countries.AddAsync(countryDto.Map());
            await _context.SaveChangesAsync();
            var returnObject = new {name = newCountry.Entity.Name, season = newCountry.Entity.Season};
            return Created(Url.Action("GetCountry", "Countries", returnObject), new CountryDto(newCountry.Entity));
        }

        [HttpPut("{name}/{season}")]
        public async Task<IActionResult> UpdateCountry(string name, string season, [FromBody] CountryDto countryDto)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (country == null) return NotFound(new {name, season});
            countryDto.MapUpdate(country);
            await _context.SaveChangesAsync();
            return Ok(new CountryDto(country));
        }

        [HttpDelete("{name}/{season}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteCountry(string name, string season)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (country == null) return NotFound(new {name, season});
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}