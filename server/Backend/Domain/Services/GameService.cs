using System;
using Domain.Enums;
using Domain.Models;

namespace Domain.Services
{
    public static class GameService
    {
        private const int MaxPace = 40;
        private const double GoalChance = 0.75;
        private const int HalfFieldLength = 100;

        public static GameResult CalculateGame(TeamLineUp homeTeam, TeamLineUp awayTeam)
        {
            var gameStatus = new GameStatus
            {
                Minute = 0,
                BallPosition = 0
            };
            var gameResult = new GameResult
            {
                HomeStrength = homeTeam.Strength,
                AwayStrength = awayTeam.Strength
            };
            while (gameStatus.Minute <= 45)
            {
                GameMovement(homeTeam, awayTeam, gameStatus);
                AttackingOpportunity(gameResult, gameStatus);
            }

            var overtime = RandomService.GetRandomNumber(0, 8);
            while (gameStatus.AddedMinutes <= overtime)
            {
                GameMovement(homeTeam, awayTeam, gameStatus, true);
                AttackingOpportunity(gameResult, gameStatus);
            }

            gameStatus.AddedMinutes = 0;

            while (gameStatus.Minute <= 90)
            {
                GameMovement(homeTeam, awayTeam, gameStatus);
                AttackingOpportunity(gameResult, gameStatus);
            }

            overtime = RandomService.GetRandomNumber(0, 8);

            while (gameStatus.AddedMinutes <= overtime)
            {
                GameMovement(homeTeam, awayTeam, gameStatus, true);
                AttackingOpportunity(gameResult, gameStatus);
            }

            return gameResult;
        }

        private static void GameMovement(
            TeamLineUp homeTeam,
            TeamLineUp awayTeam,
            GameStatus gameStatus,
            bool overtime = false)
        {
            if (overtime)
            {
                gameStatus.AddedMinutes++;
            }
            else
            {
                gameStatus.Minute++;
            }

            var progressChance = homeTeam.Strength / (homeTeam.Strength + awayTeam.Strength);
            var advancement = RandomService.GetRandomNumber(0, MaxPace);
            if (RandomService.GetRandomBetweenOneAndZero() < progressChance)
            {
                gameStatus.BallPosition += advancement;
            }
            else
            {
                gameStatus.BallPosition -= advancement;
            }
        }

        private static void AttackingOpportunity(GameResult gameResult, GameStatus gameStatus)
        {
            if (gameStatus.BallPosition > HalfFieldLength)
            {
                gameResult.GoalEvents.Add(new GoalEvent
                {
                    Minute = gameStatus.Minute,
                    AddedTime = gameStatus.AddedMinutes,
                    IsGoal = RandomService.GetRandomBetweenOneAndZero() <= GoalChance,
                    Team = Team.Home
                });
                gameStatus.BallPosition = 0;
            }
            else if (gameStatus.BallPosition < -HalfFieldLength)
            {
                gameResult.GoalEvents.Add(new GoalEvent
                {
                    Minute = gameStatus.Minute,
                    AddedTime = gameStatus.AddedMinutes,
                    IsGoal = RandomService.GetRandomBetweenOneAndZero() <= GoalChance,
                    Team = Team.Away
                });
                gameStatus.BallPosition = 0;
            }
        }
    }
}