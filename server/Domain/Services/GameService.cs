using System;
using Domain.Enums;
using Domain.Models;

namespace Domain.Services
{
    public static class GameService
    {
        public static GameResult CalculateGame_v2(TeamLineUp homeTeam, TeamLineUp awayTeam)
        {
            var gameStatus = new GameStatus
            {
                Minute = 0,
                BallPosition = 0
            };
            var gameResult = new GameResult
            {
            };

            return gameResult;
        }

        public static GameResult CalculateGame_v1(
            TeamLineUp homeTeam,
            TeamLineUp awayTeam,
            GameProperties gameProperties)
        {
            var gameStatus = new GameStatus
            {
                Minute = 0,
                BallPosition = 0,
            };
            var gameResult = new GameResult();
            var firstHalfMinutes = gameProperties.IsExtendedTime ? 15 : 45;
            while (gameStatus.Minute < firstHalfMinutes)
            {
                gameStatus.Minute++;
                for (var actionIndex = 0; actionIndex < gameProperties.ActionsPerMinute; actionIndex++)
                {
                    GameMovement(homeTeam, awayTeam, gameStatus);
                }

                AttackingOpportunity(gameResult, gameStatus, gameProperties, homeTeam, awayTeam);
                homeTeam.ApplyPotentialShift();
                awayTeam.ApplyPotentialShift();
            }

            var overtime = RandomService.GetRandomNumber(0, gameProperties.MaxOvertime);
            while (gameStatus.AddedMinutes < overtime)
            {
                gameStatus.AddedMinutes++;
                for (var actionIndex = 0; actionIndex < gameProperties.ActionsPerMinute; actionIndex++)
                {
                    GameMovement(homeTeam, awayTeam, gameStatus);
                }

                AttackingOpportunity(gameResult, gameStatus, gameProperties, homeTeam, awayTeam);
                homeTeam.ApplyPotentialShift();
                awayTeam.ApplyPotentialShift();
            }

            gameStatus.AddedMinutes = 0;

            var secondHalfMinutes = gameProperties.IsExtendedTime ? 30 : 90;
            while (gameStatus.Minute < secondHalfMinutes)
            {
                gameStatus.Minute++;
                for (var actionIndex = 0; actionIndex < gameProperties.ActionsPerMinute; actionIndex++)
                {
                    GameMovement(homeTeam, awayTeam, gameStatus);
                }

                AttackingOpportunity(gameResult, gameStatus, gameProperties, homeTeam, awayTeam);
                homeTeam.ApplyPotentialShift();
                awayTeam.ApplyPotentialShift();
            }

            overtime = RandomService.GetRandomNumber(0, gameProperties.MaxOvertime);

            while (gameStatus.AddedMinutes < overtime)
            {
                gameStatus.AddedMinutes++;
                for (var actionIndex = 0; actionIndex < gameProperties.ActionsPerMinute; actionIndex++)
                {
                    GameMovement(homeTeam, awayTeam, gameStatus);
                }

                AttackingOpportunity(gameResult, gameStatus, gameProperties, homeTeam, awayTeam);
                homeTeam.ApplyPotentialShift();
                awayTeam.ApplyPotentialShift();
            }

            return gameResult;
        }

        private static void GameMovement(
            TeamLineUp homeTeam,
            TeamLineUp awayTeam,
            GameStatus gameStatus)
        {
            var progressChance = gameStatus.Momentum == Team.Home
                ? homeTeam.AttackStrength / (homeTeam.AttackStrength + awayTeam.DefenseStrength)
                : awayTeam.AttackStrength / (awayTeam.AttackStrength + homeTeam.DefenseStrength);
            if (RandomService.GetRandomBetweenOneAndZero() < progressChance)
            {
                gameStatus.BallPosition += RandomService.GetRandomNumber(0, homeTeam.MaxPace);
                gameStatus.Momentum = Team.Home;
            }
            else
            {
                gameStatus.BallPosition -= RandomService.GetRandomNumber(0, awayTeam.MaxPace);
                gameStatus.Momentum = Team.Away;
            }
        }

        private static void AttackingOpportunity(
            GameResult gameResult,
            GameStatus gameStatus,
            GameProperties gameProperties,
            TeamLineUp homeTeam,
            TeamLineUp awayTeam)
        {
            if (gameStatus.BallPosition > gameProperties.MaxHalfFieldLength)
            {
                var isShotOnGoal = RandomService.GetRandomBetweenOneAndZero() <= homeTeam.ShotOnGoalRate;
                var goalChance = homeTeam.AttackStrength / (homeTeam.AttackStrength + awayTeam.GoalKeeperStrength);
                var isKeeperBeat = RandomService.GetRandomBetweenOneAndZero() <= goalChance;
                gameResult.GoalEvents.Add(new GoalEvent
                {
                    Minute = gameStatus.Minute,
                    AddedTime = gameStatus.AddedMinutes,
                    IsShotOnGoal = isShotOnGoal,
                    IsGoal = isKeeperBeat && isShotOnGoal,
                    Team = Team.Home
                });
                gameStatus.BallPosition = 0;
            }
            else if (gameStatus.BallPosition < -gameProperties.MaxHalfFieldLength)
            {
                var isShotOnGoal = RandomService.GetRandomBetweenOneAndZero() <= awayTeam.ShotOnGoalRate;
                var goalChance = awayTeam.AttackStrength / (awayTeam.AttackStrength + homeTeam.GoalKeeperStrength);
                var isKeeperBeat = RandomService.GetRandomBetweenOneAndZero() <= goalChance;
                gameResult.GoalEvents.Add(new GoalEvent
                {
                    Minute = gameStatus.Minute,
                    AddedTime = gameStatus.AddedMinutes,
                    IsShotOnGoal = isShotOnGoal,
                    IsGoal = isKeeperBeat && isShotOnGoal,
                    Team = Team.Away
                });
                gameStatus.BallPosition = 0;
            }
        }
    }
}