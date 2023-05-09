using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Dtos.Views;
using API.Dtos.Views.Table;
using Database.Contexts;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class SeasonProcessingService
{
    public readonly SoccerSimContext _context;

    public SeasonProcessingService(SoccerSimContext context)
    {
        _context = context;
    }

    public async Task<TableDto> GetTable(string leagueName, string season, int gameDay)
    {
        var league = await _context.Leagues
            .Include(l => l.Teams)
            .FirstOrDefaultAsync(l => l.Season == season && l.Name == leagueName);
        if (league == null) throw new InvalidOperationException("League not found");
        var teams = league.Teams.ToList();
        var table = new TableDto(teams);
        var fixtures = await _context.LeagueFixtures
            .Include(f => f.Events)
            .Include(f => f.HomeTeam)
            .Include(f => f.AwayTeam)
            .Where(f => f.LeagueName == leagueName && f.Season == season && f.GameDayNumber <= gameDay)
            .ToListAsync();
        foreach (var fixture in fixtures) table.AddFixture(new ResultDto(fixture));
        table.ApplyPositions();
        return table;
    }

    public async Task<TableDto> GetTable(string leagueName, string season)
    {
        var league = await _context.Leagues
            .Include(l => l.Teams)
            .FirstOrDefaultAsync(l => l.Season == season && l.Name == leagueName);
        if (league == null) throw new InvalidOperationException("League not found");
        var teams = league.Teams.ToList();
        var table = new TableDto(teams);
        var fixtures = await _context.LeagueFixtures
            .Include(f => f.Events)
            .Include(f => f.HomeTeam)
            .Include(f => f.AwayTeam)
            .Where(f => f.LeagueName == leagueName && f.Season == season)
            .ToListAsync();
        foreach (var fixture in fixtures) table.AddFixture(new ResultDto(fixture));
        table.ApplyPositions();
        return table;
    }

    public async Task<IEnumerable<TeamDto>> GetPromotedTeams(string leagueName, string season)
    {
        var league = await _context.Leagues
            .Include(l => l.PromotionSystem)
            .Include(l => l.Teams)
            .FirstOrDefaultAsync(l => l.Season == season && l.Name == leagueName);
        if (league == null) throw new InvalidOperationException("League not found");
        if (league.PromotionSystem == null) return Array.Empty<TeamDto>();
        var teams = league.Teams.ToList();
        var table = new TableDto(teams);
        var fixtures = await _context.LeagueFixtures
            .Include(f => f.Events)
            .Include(f => f.HomeTeam)
            .Include(f => f.AwayTeam)
            .Where(f => f.LeagueName == leagueName && f.Season == season)
            .ToListAsync();
        foreach (var fixture in fixtures) table.AddFixture(new ResultDto(fixture));
        table.ApplyPositions();
        var promotionSystem = league.PromotionSystem;
        var promotedTeams = new List<TeamDto>();
        if (promotionSystem.PromotedTeamsStart == 0) return promotedTeams;
        for (var p = promotionSystem.PromotedTeamsStart; p <= promotionSystem.PromotedTeamsEnd; p++)
        {
            var teamName = table.Positions.First(pos => pos.Position == p).TeamName;
            var team = teams.FirstOrDefault(t => t.Name == teamName);
            promotedTeams.Add(new TeamDto(team));
        }

        return promotedTeams;
    }

    public async Task<IEnumerable<TeamDto>> GetTeamsInPromotionPlayOff(string leagueName, string season)
    {
        var league = await _context.Leagues
            .Include(l => l.PromotionSystem)
            .Include(l => l.Teams)
            .FirstOrDefaultAsync(l => l.Season == season && l.Name == leagueName);
        if (league == null) throw new InvalidOperationException("League not found");
        if (league.PromotionSystem == null) return Array.Empty<TeamDto>();
        var teams = league.Teams.ToList();
        var table = new TableDto(teams);
        var fixtures = await _context.LeagueFixtures
            .Include(f => f.Events)
            .Include(f => f.HomeTeam)
            .Include(f => f.AwayTeam)
            .Where(f => f.LeagueName == leagueName && f.Season == season)
            .ToListAsync();
        foreach (var fixture in fixtures) table.AddFixture(new ResultDto(fixture));
        table.ApplyPositions();
        var promotionSystem = league.PromotionSystem;
        var teamsInPlayOff = new List<TeamDto>();
        if (promotionSystem.PromotionPlayOffTeamsStart == 0) return teamsInPlayOff;
        for (var p = promotionSystem.PromotionPlayOffTeamsStart; p <= promotionSystem.PromotionPlayOffTeamsEnd; p++)
        {
            var teamName = table.Positions.First(pos => pos.Position == p).TeamName;
            var team = teams.FirstOrDefault(t => t.Name == teamName);
            teamsInPlayOff.Add(new TeamDto(team));
        }

        return teamsInPlayOff;
    }

    public async Task<IEnumerable<TeamDto>> GetRelegatedTeams(string leagueName, string season)
    {
        var league = await _context.Leagues
            .Include(l => l.PromotionSystem)
            .Include(l => l.Teams)
            .FirstOrDefaultAsync(l => l.Season == season && l.Name == leagueName);
        if (league == null) throw new InvalidOperationException("League not found");
        if (league.PromotionSystem == null) return Array.Empty<TeamDto>();
        var teams = league.Teams.ToList();
        var table = new TableDto(teams);
        var fixtures = await _context.LeagueFixtures
            .Include(f => f.Events)
            .Include(f => f.HomeTeam)
            .Include(f => f.AwayTeam)
            .Where(f => f.LeagueName == leagueName && f.Season == season)
            .ToListAsync();
        foreach (var fixture in fixtures) table.AddFixture(new ResultDto(fixture));
        table.ApplyPositions();
        var promotionSystem = league.PromotionSystem;
        var relegatedTeams = new List<TeamDto>();
        if (promotionSystem.RelegatedTeamsStart == 0) return relegatedTeams;
        for (var p = promotionSystem.RelegatedTeamsStart; p <= promotionSystem.RelegatedTeamsEnd; p++)
        {
            var teamName = table.Positions.First(pos => pos.Position == p).TeamName;
            var team = teams.FirstOrDefault(t => t.Name == teamName);
            relegatedTeams.Add(new TeamDto(team));
        }

        return relegatedTeams;
    }

    public async Task<IEnumerable<TeamDto>> GetTeamsInRelegationPlayoff(string leagueName, string season)
    {
        var league = await _context.Leagues
            .Include(l => l.PromotionSystem)
            .Include(l => l.Teams)
            .FirstOrDefaultAsync(l => l.Season == season && l.Name == leagueName);
        if (league == null) throw new InvalidOperationException("League not found");
        if (league.PromotionSystem == null) return Array.Empty<TeamDto>();
        var teams = league.Teams.ToList();
        var table = new TableDto(teams);
        var fixtures = await _context.LeagueFixtures
            .Include(f => f.Events)
            .Include(f => f.HomeTeam)
            .Include(f => f.AwayTeam)
            .Where(f => f.LeagueName == leagueName && f.Season == season)
            .ToListAsync();
        foreach (var fixture in fixtures) table.AddFixture(new ResultDto(fixture));
        table.ApplyPositions();
        var promotionSystem = league.PromotionSystem;
        var teamsInPlayOff = new List<TeamDto>();
        if (promotionSystem.RelegationPlayOffTeamsStart == 0) return teamsInPlayOff;
        for (var p = promotionSystem.RelegationPlayOffTeamsStart; p <= promotionSystem.RelegationPlayOffTeamsEnd; p++)
        {
            var teamName = table.Positions.First(pos => pos.Position == p).TeamName;
            var team = teams.FirstOrDefault(t => t.Name == teamName);
            teamsInPlayOff.Add(new TeamDto(team));
        }

        return teamsInPlayOff;
    }

    public async Task<DivisionProcessingStatus> GetDivisionProcessingStatus(string season, string divisionName)
    {
        var division = await _context.Divisions.FirstOrDefaultAsync(d => d.Season == season && d.Name == divisionName);
        if (division == null) throw new InvalidOperationException("Division not found");
        var newDivision = new Division(division);
        var promotedUp = new List<TeamDto>(); // The teams getting promoted out of this division.
        var relegatedDown = new List<TeamDto>(); // The teams getting relegated out of this division.
        var promotedTeams = new List<TeamDto>(); // The teams getting promoted into this division.
        var relegatedTeams = new List<TeamDto>(); // The teams getting relegated into this division.
        var promotionPlayoffPot = new List<TeamDto>(); // The teams in the promotion playoff pot.
        var relegationPlayoffPot = new List<TeamDto>(); // The teams in the relegation playoff pot.
        foreach (var league in division.Leagues.ToList())
        {
            promotedUp.AddRange(await GetPromotedTeams(league.Name, season));
            relegatedDown.AddRange(await GetRelegatedTeams(league.Name, season));
            promotionPlayoffPot.AddRange(
                await GetTeamsInPromotionPlayOff(league.Name, season));
            relegationPlayoffPot.AddRange(
                await GetTeamsInRelegationPlayoff(league.Name, season));

            // Teams get relegated from lower divisions to higher ones.
            var lowerDivision = await GetLowerDivision(division);
            var lowerLeagues = lowerDivision.Leagues;
            var newTeams = new List<TeamDto>(); // Holds all the teams that get promoted or relegated to this division.
            promotionPlayoffPot.AddRange(promotionPlayoffPot);
            foreach (var lowerLeague in lowerLeagues)
            {
                promotionPlayoffPot.AddRange(
                    await GetTeamsInRelegationPlayoff(lowerLeague.Name, season));
                relegatedTeams.AddRange(await GetRelegatedTeams(lowerLeague.Name, season));
            }

            // Teams get promoted from higher divisions to lower ones.
            var higherDivision = await GetHigherDivision(division);
            var higherLeagues = higherDivision.Leagues;
            relegationPlayoffPot.AddRange(relegationPlayoffPot);
            foreach (var higherLeague in higherLeagues)
            {
                relegationPlayoffPot.AddRange(
                    await GetTeamsInPromotionPlayOff(higherLeague.Name, season));
                promotedTeams.AddRange(await GetPromotedTeams(higherLeague.Name, season));
            }
        }

        var response = new DivisionProcessingStatus
        {
            PromotedTeams = promotedUp,
            RelegatedTeams = relegatedDown,
            PromoPlayoffTeams = promotionPlayoffPot,
            RelegationPlayoffTeams = relegationPlayoffPot,
            PromotedIntoThisDivision = promotedTeams,
            RelegatedIntoThisDivision = relegatedTeams
        };

        return response;
    }
    
    private async Task<Division> GetLowerDivision(Division division)
    {
        var lowerDivision = await _context.Divisions
            .Include(d => d.Leagues)
            .ThenInclude(l => l.Teams)
            .FirstOrDefaultAsync(d =>
                d.CountryName == division.CountryName && 
                d.Season == division.Season &&
                d.Level == division.Level - 1);
        return lowerDivision;
    }
    
    private async Task<Division> GetHigherDivision(Division division)
    {
        var higherDivision = await _context.Divisions
            .Include(d => d.Leagues)
            .ThenInclude(l => l.Teams)
            .FirstOrDefaultAsync(d => 
                d.CountryName == division.CountryName && 
                d.Season == division.Season && 
                d.Level == division.Level + 1);
        return higherDivision;
    }
}