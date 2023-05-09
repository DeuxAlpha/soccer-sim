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
        private static GameResult ProcessGame(LeagueFixture fixture)
        {
            return GameService.CalculateGame_v1(new TeamLineUp
                {
                    AttackStrength = fixture.HomeTeam.AttackStrength,
                    DefenseStrength = fixture.HomeTeam.DefenseStrength,
                    GoalKeeperStrength = fixture.HomeTeam.GoalieStrength,
                    CurrentForm = 0,
                    MaxPace = fixture.HomeTeam?.MaxPace ?? 35,
                    ShotOnGoalRate = fixture.HomeTeam?.ShotOnGoalRate ?? 0.3,
                    PotentialPositiveShift = fixture.HomeTeam?.PotentialPositiveShift ?? 0,
                    PotentialPositiveShiftChance = fixture.HomeTeam?.PotentialPositiveChance ?? 0,
                    PotentialNegativeShift = fixture.HomeTeam?.PotentialNegativeShift ?? 0,
                    PotentialNegativeShiftChance = fixture.HomeTeam?.PotentialNegativeChance ?? 0,
                }, new TeamLineUp
                {
                    AttackStrength = fixture.AwayTeam.AttackStrength,
                    DefenseStrength = fixture.AwayTeam.DefenseStrength,
                    GoalKeeperStrength = fixture.AwayTeam.GoalieStrength,
                    CurrentForm = 0,
                    MaxPace = fixture.AwayTeam?.MaxPace ?? 35,
                    ShotOnGoalRate = fixture.AwayTeam?.ShotOnGoalRate ?? 0.3,
                    PotentialPositiveShift = fixture.AwayTeam?.PotentialPositiveShift ?? 0,
                    PotentialPositiveShiftChance = fixture.AwayTeam?.PotentialPositiveChance ?? 0,
                    PotentialNegativeShift = fixture.AwayTeam?.PotentialNegativeShift ?? 0,
                    PotentialNegativeShiftChance = fixture.AwayTeam?.PotentialNegativeChance ?? 0,
                }, new GameProperties
                {
                    PaceModifier = fixture.PaceModifier,
                    ShotAccuracyModifier = fixture.ShotAccuracyModifier,
                    ActionsPerMinute = fixture.ActionsPerMinute,
                    MaxProgressChance = fixture.League?.MaxProgressChance ?? 1,
                    MinProgressChance = fixture.League?.MinProgressChance ?? 0,
                    MaxHomeAdvantage = fixture.MaxHomeAdvantage,
                    MaxAwayDisadvantage = fixture.MaxAwayDisadvantage
                });
        }

        public static ResultDto SimulateGame(LeagueFixture fixture)
        {
            var result = ProcessGame(fixture);
            fixture.HomePossession = (int) Math.Round(result.HomePossession * 100, 0);
            fixture.AwayPossession = (int) Math.Round(result.AwayPossession * 100, 0);
            fixture.Events = result.GoalEvents.Select(e => MapToLFE(e, fixture)).ToList();
            result.GoalEvents = result.GoalEvents;
            return new ResultDto(fixture);
        }

        public static async Task<ResultDto> StoreFixtureResult(LeagueFixture fixture, SoccerSimContext context)
        {
            var result = ProcessGame(fixture);
            fixture.HomePossession = (int) Math.Round(result.HomePossession * 100, 0);
            fixture.AwayPossession = (int) Math.Round(result.AwayPossession * 100, 0);
            var goalEvents = result.GoalEvents.Select(e => MapToLFE(e, fixture)).ToList();
            await context.LeagueFixtureEvents.AddRangeAsync(goalEvents); 
            return new ResultDto(fixture);
        }

        private static LeagueFixtureEvent MapToLFE(GoalEvent goalEvent, LeagueFixture fixture)
        {
            return new LeagueFixtureEvent
            {
                HomeTeamName = fixture.HomeTeamName,
                AwayTeamName = fixture.AwayTeamName,
                Season = fixture.Season,
                LeagueName = fixture.LeagueName,
                GameDayNumber = fixture.GameDayNumber,
                Minute = goalEvent.Minute,
                AddedMinute = goalEvent.AddedTime,
                IsGoal = goalEvent.IsGoal,
                IsShotOnGoal = goalEvent.IsShotOnGoal,
                EventTeamName = goalEvent.ActingTeam == ActingTeam.Home ? fixture.HomeTeamName : fixture.AwayTeamName
            };
        }
    }
}