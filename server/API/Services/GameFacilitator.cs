using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Views;
using Database.Contexts;
using Database.Models;
using Domain.Enums;
using Domain.Models;
using Domain.Services;

namespace API.Services
{
    public static class GameFacilitator
    {
        private static GameResult SimulateGame(LeagueFixture fixture)
        {
            return GameService.CalculateGame_v1(new TeamLineUp
                {
                    AttackStrength = fixture.HomeTeam.AttackStrength,
                    DefenseStrength = fixture.HomeTeam.DefenseStrength,
                    GoalKeeperStrength = fixture.HomeTeam.GoalieStrength,
                    CurrentForm = 0,
                    MaxPace = fixture.HomeTeam.MaxPace,
                    ShotOnGoalRate = fixture.HomeTeam.ShotOnGoalRate,
                    PotentialPositiveShift = fixture.HomeTeam.PotentialPositiveShift,
                    PotentialPositiveShiftChance = fixture.HomeTeam.PotentialPositiveChance,
                    PotentialNegativeShift = fixture.HomeTeam.PotentialNegativeShift,
                    PotentialNegativeShiftChance = fixture.HomeTeam.PotentialNegativeChance,
                }, new TeamLineUp
                {
                    AttackStrength = fixture.AwayTeam.AttackStrength,
                    DefenseStrength = fixture.AwayTeam.DefenseStrength,
                    GoalKeeperStrength = fixture.AwayTeam.GoalieStrength,
                    CurrentForm = 0,
                    MaxPace = fixture.AwayTeam.MaxPace,
                    ShotOnGoalRate = fixture.AwayTeam.ShotOnGoalRate,
                    PotentialPositiveShift = fixture.AwayTeam.PotentialPositiveShift,
                    PotentialPositiveShiftChance = fixture.AwayTeam.PotentialPositiveChance,
                    PotentialNegativeShift = fixture.AwayTeam.PotentialNegativeShift,
                    PotentialNegativeShiftChance = fixture.AwayTeam.PotentialNegativeChance,
                }, new GameProperties
                {
                    PaceModifier = fixture.PaceModifier,
                    ShotAccuracyModifier = fixture.ShotAccuracyModifier,
                    ActionsPerMinute = fixture.ActionsPerMinute,
                    MaxProgressChance = fixture.League.MaxProgressChance,
                    MinProgressChance = fixture.League.MinProgressChance,
                    MaxHomeAdvantage = fixture.MaxHomeAdvantage,
                    MaxAwayDisadvantage = fixture.MaxAwayDisadvantage
                });
        }

        public static async Task<ResultDto> StoreFixtureResult(LeagueFixture fixture, SoccerSimContext context)
        {
            var result = SimulateGame(fixture);
            fixture.HomePossession = (int) Math.Round(result.HomePossession * 100, 0);
            fixture.AwayPossession = (int) Math.Round(result.AwayPossession * 100, 0);
            var goalEvents = result.GoalEvents.Select(e => new LeagueFixtureEvent
            {
                HomeTeamName = fixture.HomeTeamName,
                AwayTeamName = fixture.AwayTeamName,
                Season = fixture.Season,
                LeagueName = fixture.LeagueName,
                GameDayNumber = fixture.GameDayNumber,
                Minute = e.Minute,
                AddedMinute = e.AddedTime,
                IsGoal = e.IsGoal,
                IsShotOnGoal = e.IsShotOnGoal,
                EventTeamName = e.ActingTeam == ActingTeam.Home ? fixture.HomeTeamName : fixture.AwayTeamName
            }).ToList();
            await context.LeagueFixtureEvents.AddRangeAsync(goalEvents);
            return new ResultDto(fixture);
        }
    }
}