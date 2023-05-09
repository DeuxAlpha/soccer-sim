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

    public CompetitionsController(SoccerSimContext context, ILogger<CompetitionsController> logger)
    {
        _context = context;
        _logger = logger;
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
    public async Task<ActionResult> ProcessPlayoff(string season, DivisionSeasonPlayoffRequest request)
    {
        // check if request teams are to the power of 2
        var playoffTeams = request.Teams.ToList();
        var count = playoffTeams.Count;
        var power = 0;
        while (count % 2 == 0 && count > 1)
        {
            count /= 2;
            power++;
        }
        _logger.LogInformation("Power: {Power}", power);

        if (count == 1)
        {
            var teamCollection = new List<Team>();
            foreach (var playoffTeam in playoffTeams)
            {
                var team = await _context.Teams.FirstOrDefaultAsync(t => t.Season == season && t.Name == playoffTeam);
                if (team == null) return NotFound(new {season, playoffTeam});
                teamCollection.Add(team);
            }
            // Create rounds of playoffs until there is a winner
            // Pull from the first and last of the collection to create a game.
            // The winner of the game goes to the next round.
            // The loser is eliminated.
            // Repeat until there is a winner.
            var round = 1;
            var maxRounds = power;
            var winners = teamCollection;
            var losers = new List<Team>();
            var results = new List<ResultDto>();

            while (round <= maxRounds)
            {
                var roundGames = new List<MatchUp<Team>>();
                for (var i = 0; i < winners.Count / 2; i++)
                {
                    var homeTeam = winners[i];
                    var awayTeam = winners[winners.Count - i - 1];
                    var game = new MatchUp<Team>
                    {
                        Home = homeTeam,
                        Away = awayTeam
                    };
                    roundGames.Add(game);
                }

                var roundWinners = new List<Team>();
                foreach (var game in roundGames)
                {
                    var result = ProcessGame(game.Home, game.Away);
                    results.Add(result);
                    while (result.Winner == "Draw")
                    {
                        result = ProcessGame(game.Home, game.Away);
                        results.Add(result);
                    }
                    // add the winning team to the winners list
                    var winningTeam = result.Winner == game.Home.Name ? game.Home : game.Away;
                    roundWinners.Add(winningTeam);
                    // add the losing team to the losers list
                    var losingTeam = result.Loser == game.Home.Name ? game.Home : game.Away;
                    losers.Add(losingTeam);
                }

                // set the winners for the next round
                winners = roundWinners;
                round++;
            }

            // the last team in the winners list is the champion
            var champion = winners.First();

            return Ok(new
            {
                Champion = champion.Name,
                Losers = losers.Select(l => l.Name),
                Results = results.Select(r => $"{r.Fixture} {r.Score}{r.HalfTimeScore}")
            });
        }
        else
        {
            return BadRequest(new {Message = "Teams must be to the power of 2"});
        }
    }
}