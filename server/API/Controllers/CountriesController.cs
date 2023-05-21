using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Dtos.Requests;
using API.Dtos.Responses;
using API.Dtos.Views;
using API.Dtos.Views.Table;
using API.Services;
using Database.Contexts;
using Database.Models;
using DynamicQuerying.Main.Query.Models;
using DynamicQuerying.Main.Query.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly SoccerSimContext _context;
        private readonly SeasonProcessingService _seasonProcessingService;

        public CountriesController(SoccerSimContext context, SeasonProcessingService seasonProcessingService)
        {
            _context = context;
            _seasonProcessingService = seasonProcessingService;
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

        [HttpPost("{name}/{season}/process/{newSeason}")]
        public async Task<ActionResult<CountrySeasonProcessResponse>> ProcessCountry(string name, string season, string newSeason)
        {
            var country = await _context.Countries
                .Include(c => c.Divisions)
                .ThenInclude(d => d.Leagues)
                .ThenInclude(l => l.PromotionSystem)
                .Include(c => c.Divisions)
                .ThenInclude(d => d.Leagues)
                .ThenInclude(l => l.Teams)
                .FirstOrDefaultAsync(c => c.Name == name && c.Season == season);
            if (country == null) return NotFound(new {name, season});
            var divisionsBottomToTop = country.Divisions.OrderByDescending(d => d.Level).ToList();
            var prevPromoted = new List<TeamDto>();
            var prevRelegated = new List<TeamDto>();
            var results = new List<PlayoffResultDto>();
            var newLeagues = new List<LeagueInfoDto>();
            for (var divIdx = 0; divIdx < divisionsBottomToTop.Count; divIdx++)
            {
                var division = divisionsBottomToTop[divIdx];
                var divisionStatus = await _seasonProcessingService.GetDivisionProcessingStatus(season, division.Name);
                var relegatedTeams = divisionStatus.RelegatedIntoThisDivision.ToList();
                var promotedTeams = divisionStatus.PromotedIntoThisDivision.ToList();
                foreach (var relegatedTeam in relegatedTeams)
                {
                    relegatedTeam.RelegationFlag = true;
                    relegatedTeam.PromotionFlag = false;
                }

                foreach (var promotedTeam in promotedTeams)
                {
                    promotedTeam.PromotionFlag = true;
                    promotedTeam.RelegationFlag = false;
                }
                var divisionTeams = division.Leagues.SelectMany(l => l.Teams).Select(t => new TeamDto(t)).ToList();
                foreach (var team in divisionTeams)
                {
                    team.ChampionFlag = false;
                    team.RelegationFlag = false;
                    team.PromotionFlag = false;
                }
                if (divisionStatus.Champion != null)
                {
                    var champ = divisionTeams.FirstOrDefault(t => t.Name == divisionStatus.Champion.Name);
                    if (champ != null) champ.ChampionFlag = true;
                }
                foreach (var promotedTeam in divisionStatus.PromotedTeams)
                {
                    var divTeam = divisionTeams.FirstOrDefault(t => t.Name == promotedTeam.Name);
                    if (divTeam == null)
                    {
                        continue;
                    }

                    divisionTeams.Remove(divTeam);
                }
                foreach (var relegatedTeam in divisionStatus.RelegatedTeams)
                {
                    var divTeam = divisionTeams.FirstOrDefault(t => t.Name == relegatedTeam.Name);
                    if (divTeam == null) continue;
                    divisionTeams.Remove(divTeam);
                }

                foreach (var prom in prevPromoted)
                {
                    prom.PromotionFlag = true;
                    prom.RelegationFlag = false;
                }
                
                divisionTeams.AddRange(prevPromoted);

                divisionTeams.AddRange(relegatedTeams);
                divisionTeams.AddRange(promotedTeams);

                foreach (var rel in prevRelegated)
                {
                    var divTeam = divisionTeams.FirstOrDefault(t => t.Name == rel.Name);
                    if (divTeam == null) continue;
                    divisionTeams.Remove(divTeam);
                }
                
                var promoResult = await _seasonProcessingService
                    .CreatePlayoff(divisionStatus.PromoPlayoffTeams.Select(t => t.Name), season);
                if (promoResult != null)
                {
                    results.Add(promoResult);

                    var losers = divisionStatus.PromoPlayoffTeams.Where(t => promoResult.Losers.Contains(t.Name)).ToList();
                    foreach (var loser in losers)
                    {
                        // If the loser is a different league than promoted team, then flag them as relegated.
                        var promoTeam = divisionStatus.PromotedTeams.FirstOrDefault();
                        if (promoTeam != null)
                        {
                            loser.RelegationFlag = loser.LeagueName != promoTeam.LeagueName;
                        }
                        var existing = divisionTeams.FirstOrDefault(t => t.Name == loser.Name);
                        if (existing == null) divisionTeams.Add(loser);
                    }
                    prevRelegated = losers;
                    var divChampion = divisionTeams.FirstOrDefault(t => t.Name == promoResult.Champion);
                    if (divChampion != null) divisionTeams.Remove(divChampion);
                    prevPromoted.AddRange(divisionStatus.PromoPlayoffTeams.Where(t => promoResult.Champion == t.Name).ToList());
                    foreach (var prom in prevPromoted)
                    {
                        prom.PromotionFlag = true;
                    }
                }

                var divisionLeaguesCount = division.Leagues.Count();
                // This is so that teams that have played together stay together
                divisionTeams = divisionTeams.OrderBy(t => t.LeagueName).DistinctBy(t => t.Name).ToList();
                var teamsPerLeague = divisionTeams.Count / divisionLeaguesCount;
                
                // Create new continent if not exist
                var newContinent = await _context.Continents
                    .FirstOrDefaultAsync(c => c.Name == country.ContinentName && c.Season == newSeason);
                if (newContinent == null)
                {
                    newContinent = new Continent();
                    newContinent.Name = country.ContinentName;
                    newContinent.Season = newSeason;
                    var response = await _context.Continents.AddAsync(newContinent);
                    await _context.SaveChangesAsync();
                    newContinent = response.Entity;
                }
                
                // Create new country if not exist
                var newCountry = await _context.Countries
                    .FirstOrDefaultAsync(c => c.Name == country.Name && c.Season == newSeason);
                if (newCountry == null)
                {
                    newCountry = new Country(country);
                    newCountry.Season = newSeason;
                    var response = await _context.Countries.AddAsync(newCountry);
                    await _context.SaveChangesAsync();
                    newCountry = response.Entity;
                }
                // Create new division if not exist
                var newDivision = await _context.Divisions
                    .FirstOrDefaultAsync(d => d.Name == division.Name && d.Season == newSeason);
                if (newDivision == null)
                {
                    newDivision = new Division(division);
                    newDivision.Season = newSeason;
                    var response = await _context.Divisions.AddAsync(newDivision);
                    await _context.SaveChangesAsync();
                    newDivision = response.Entity;
                }

                for (var leagueIdx = 0; leagueIdx < divisionLeaguesCount; leagueIdx++)
                {
                    var leagueResponse = new LeagueInfoDto();
                    var league = division.Leagues.ElementAt(leagueIdx);
                    var newLeague = await _context.Leagues
                        .FirstOrDefaultAsync(l => l.Name == league.Name && l.Season == newSeason);
                    if (newLeague == null)
                    {
                        newLeague = new League(league);
                        newLeague.Season = newSeason;
                        var response = await _context.Leagues.AddAsync(newLeague);
                        await _context.SaveChangesAsync();
                        newLeague = response.Entity;
                    }

                    var existingPromoSystem = await _context.PromotionSystems
                        .FirstOrDefaultAsync(p => p.Season == newSeason && p.LeagueName == newLeague.Name);
                    if (existingPromoSystem == null)
                    {
                        var promoSystem = league.PromotionSystem ?? new PromotionSystem();
                        promoSystem.Season = newSeason;
                        promoSystem.LeagueName = league.Name;
                        var response = await _context.PromotionSystems.AddAsync(promoSystem);
                        await _context.SaveChangesAsync();
                    }
                    
                    for (var teamIdx = 0; teamIdx < teamsPerLeague; teamIdx++)
                    {
                        var team = divisionTeams[leagueIdx * teamsPerLeague + teamIdx];
                        team.LeagueName = league.Name;
                        team.Season = newSeason;
                        var response = await _context.Teams.AddAsync(team.Map());
                        leagueResponse.Teams.Add(team.Name);
                        await _context.SaveChangesAsync();
                    }
                    newLeagues.Add(new LeagueInfoDto{Teams = leagueResponse.Teams});
                }
            }

            var processResponse = new CountrySeasonProcessResponse
            {
                NewSeason = newSeason,
                Playoffs = results,
                Leagues = newLeagues
            };

            return Ok(processResponse);
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