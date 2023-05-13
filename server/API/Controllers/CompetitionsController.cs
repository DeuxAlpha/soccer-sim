using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Requests;
using API.Dtos.Views;
using API.Services;
using Database.Contexts;
using Database.Models;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CompetitionsController : ControllerBase
{
    private readonly SoccerSimContext _context;
    private readonly ILogger<CompetitionsController> _logger;
    private readonly SeasonProcessingService _seasonProcessingService;

    public CompetitionsController(SoccerSimContext context, ILogger<CompetitionsController> logger, SeasonProcessingService seasonProcessingService)
    {
        _context = context;
        _logger = logger;
        _seasonProcessingService = seasonProcessingService;
    }

    [HttpPost("game/{season}/{homeTeam}/{awayTeam}")]
    public async Task<ActionResult<ResultDto>> GetGameResult(string season, string homeTeam, string awayTeam)
    {
        var home = await _context.Teams.FirstOrDefaultAsync(t => t.Season == season && t.Name == homeTeam);
        if (home == null) return NotFound(new {season, homeTeam});
        var away = await _context.Teams.FirstOrDefaultAsync(t => t.Season == season && t.Name == awayTeam);
        if (away == null) return NotFound(new {season, awayTeam});
        var result = ProcessGame(home, away);
        return Ok(result);
    }

    private ResultDto ProcessGame(Team home, Team away)
    {
        var result = GameFacilitator.SimulateGame(new LeagueFixture
        {
            HomeTeam = home,
            AwayTeam = away,
            HomeTeamName = home.Name,
            AwayTeamName = away.Name,
            ActionsPerMinute = 4,
            PaceModifier = 1,
            ShotAccuracyModifier = 1
        });
        return result;
    }
    
    [HttpPost("{season}/playoff")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PlayoffResultDto>> ProcessPlayoff(string season, DivisionSeasonPlayoffRequest request)
    {
        try
        {
            var result = await _seasonProcessingService.CreatePlayoff(request.Teams, season);
            if (result == null) return BadRequest(new { Message = "No teams were provided in the playoff" });
            return Ok(result);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Unhandled exception");
            return BadRequest(new
            {
                Message = exception.Message
            });
        }
    }
}