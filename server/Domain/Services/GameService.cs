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
            var gameResult = new GameResult();

            return gameResult;
        }

        public static PenaltiesResult CalculatePenalties()
        {
            var result = new PenaltiesResult();
            var homeShoots = true;
            var tries = 0;
            var maxTries = 10;
            while (tries != maxTries)
            {
                tries++;
                RandomService.GetRandomBetweenOneAndZero();
                if (RandomService.GetRandomBetweenOneAndZero() <= 0.75)
                {
                    if (homeShoots)
                    {
                        result.PenaltyEvents.Add(new PenaltyEvent
                        {
                            ActingTeam = ActingTeam.Home,
                            IsGoal = true
                        });
                        homeShoots = false;
                    }
                    else
                    {
                        result.PenaltyEvents.Add(new PenaltyEvent
                        {
                            ActingTeam = ActingTeam.Away,
                            IsGoal = true
                        });
                        homeShoots = true;
                    }
                }
                else if (homeShoots)
                {
                    result.PenaltyEvents.Add(new PenaltyEvent
                    {
                        ActingTeam = ActingTeam.Home,
                        IsGoal = false
                    });
                    homeShoots = false;
                }
                else
                {
                    result.PenaltyEvents.Add(new PenaltyEvent
                    {
                        ActingTeam = ActingTeam.Away,
                        IsGoal = false
                    });
                    homeShoots = true;
                }
                if (tries == maxTries && result.HomeGoals == result.AwayGoals)
                {
                    maxTries += 2;
                }
            }

            return result;
        }

        public static GameResult CalculateGame_v1(
            TeamLineUp homeTeam,
            TeamLineUp awayTeam,
            GameProperties gameProperties)
        {
            var gameResult = new GameResult
            {
                PreHomeTeam = homeTeam.Clone(),
                PreAwayTeam = awayTeam.Clone()
            };
            homeTeam.AttackStrength += RandomService.GetRandomNumber(0, gameProperties.MaxHomeAdvantage);
            homeTeam.DefenseStrength += RandomService.GetRandomNumber(0, gameProperties.MaxHomeAdvantage);
            homeTeam.GoalKeeperStrength += RandomService.GetRandomNumber(0, gameProperties.MaxHomeAdvantage);
            awayTeam.AttackStrength -= RandomService.GetRandomNumber(0, gameProperties.MaxAwayDisadvantage);
            awayTeam.DefenseStrength -= RandomService.GetRandomNumber(0, gameProperties.MaxAwayDisadvantage);
            awayTeam.GoalKeeperStrength -= RandomService.GetRandomNumber(0, gameProperties.MaxAwayDisadvantage);
            if (homeTeam.CurrentForm > 0)
            {
                homeTeam.AttackStrength += RandomService.GetRandomNumber(0, homeTeam.CurrentForm);
                homeTeam.DefenseStrength += RandomService.GetRandomNumber(0, homeTeam.CurrentForm);
                homeTeam.GoalKeeperStrength += RandomService.GetRandomNumber(0, homeTeam.CurrentForm);
            }
            else if (homeTeam.CurrentForm < 0)
            {
                homeTeam.AttackStrength += RandomService.GetRandomNumber(homeTeam.CurrentForm, 0);
                homeTeam.DefenseStrength += RandomService.GetRandomNumber(homeTeam.CurrentForm, 0);
                homeTeam.GoalKeeperStrength += RandomService.GetRandomNumber(homeTeam.CurrentForm, 0);
            }
            if (awayTeam.CurrentForm > 0)
            {
                awayTeam.AttackStrength += RandomService.GetRandomNumber(0, awayTeam.CurrentForm);
                awayTeam.DefenseStrength += RandomService.GetRandomNumber(0, awayTeam.CurrentForm);
                awayTeam.GoalKeeperStrength += RandomService.GetRandomNumber(0, awayTeam.CurrentForm);
            }
            else if (awayTeam.CurrentForm < 0)
            {
                awayTeam.AttackStrength += RandomService.GetRandomNumber(awayTeam.CurrentForm, 0);
                awayTeam.DefenseStrength += RandomService.GetRandomNumber(awayTeam.CurrentForm, 0);
                awayTeam.GoalKeeperStrength += RandomService.GetRandomNumber(awayTeam.CurrentForm, 0);
            }
            var gameStatus = new GameStatus
            {
                Minute = 0,
                BallPosition = 0,
            };
            var firstHalfMinutes = gameProperties.IsExtendedTime ? 15 : 45;
            while (gameStatus.Minute < firstHalfMinutes)
            {
                gameStatus.Minute++;
                for (var actionIndex = 0; actionIndex < gameProperties.ActionsPerMinute; actionIndex++)
                {
                    GameMovement(homeTeam, awayTeam, gameStatus, gameProperties);
                    gameResult.Possessions.Add(gameStatus.Momentum);
                }

                AttackingOpportunity(gameResult, gameStatus, gameProperties, homeTeam, awayTeam);
            }

            var overtime = RandomService.GetRandomNumber(0, gameProperties.MaxOvertime);
            while (gameStatus.AddedMinutes < overtime)
            {
                gameStatus.AddedMinutes++;
                for (var actionIndex = 0; actionIndex < gameProperties.ActionsPerMinute; actionIndex++)
                {
                    GameMovement(homeTeam, awayTeam, gameStatus, gameProperties);
                    gameResult.Possessions.Add(gameStatus.Momentum);
                }

                AttackingOpportunity(gameResult, gameStatus, gameProperties, homeTeam, awayTeam);
            }
            homeTeam.ApplyPotentialShift();
            awayTeam.ApplyPotentialShift();

            gameStatus.AddedMinutes = 0;

            var secondHalfMinutes = gameProperties.IsExtendedTime ? 30 : 90;
            while (gameStatus.Minute < secondHalfMinutes)
            {
                gameStatus.Minute++;
                for (var actionIndex = 0; actionIndex < gameProperties.ActionsPerMinute; actionIndex++)
                {
                    GameMovement(homeTeam, awayTeam, gameStatus, gameProperties);
                    gameResult.Possessions.Add(gameStatus.Momentum);
                }

                AttackingOpportunity(gameResult, gameStatus, gameProperties, homeTeam, awayTeam);
            }

            overtime = RandomService.GetRandomNumber(0, gameProperties.MaxOvertime);

            while (gameStatus.AddedMinutes < overtime)
            {
                gameStatus.AddedMinutes++;
                for (var actionIndex = 0; actionIndex < gameProperties.ActionsPerMinute; actionIndex++)
                {
                    GameMovement(homeTeam, awayTeam, gameStatus, gameProperties);
                    gameResult.Possessions.Add(gameStatus.Momentum);
                }

                AttackingOpportunity(gameResult, gameStatus, gameProperties, homeTeam, awayTeam);
            }

            gameResult.PostHomeTeam = homeTeam.Clone();
            gameResult.PostAwayTeam = homeTeam.Clone();
            return gameResult;
        }

        private static void GameMovement(
            TeamLineUp homeTeam,
            TeamLineUp awayTeam,
            GameStatus gameStatus,
            GameProperties gameProperties)
        {
            var progressChance = GetProgressChance(homeTeam, awayTeam, gameStatus);
            // Cap chances. Otherwise it becomes impossible for teams to win against superior opponents
            if (progressChance < gameProperties.MinProgressChance) progressChance = gameProperties.MinProgressChance;
            if (progressChance > gameProperties.MaxProgressChance) progressChance = gameProperties.MaxProgressChance;
            if (RandomService.GetRandomBetweenOneAndZero() < progressChance)
            {
                var maxPace = homeTeam.MaxPace * gameProperties.PaceModifier;
                gameStatus.BallPosition += (int) RandomService.GetRandomNumber(0, maxPace);
                gameStatus.Momentum = ActingTeam.Home;
            }
            else
            {
                var maxPace = awayTeam.MaxPace * gameProperties.PaceModifier;
                gameStatus.BallPosition -= (int) RandomService.GetRandomNumber(0, maxPace);
                gameStatus.Momentum = ActingTeam.Away;
            }
        }

        private static double GetProgressChance(TeamLineUp homeTeam, TeamLineUp awayTeam, GameStatus gameStatus)
        {
            if (gameStatus.BallPosition > 0)
            {
                return homeTeam.AttackStrength / (homeTeam.AttackStrength + awayTeam.DefenseStrength);
            }
            else if (gameStatus.BallPosition < 0)
            {
                return homeTeam.DefenseStrength / (homeTeam.DefenseStrength + awayTeam.AttackStrength);
            }

            return 0.5;
        }

        private static void AttackingOpportunity(
            GameResult gameResult,
            GameStatus gameStatus,
            GameProperties gameProperties,
            TeamLineUp homeTeam,
            TeamLineUp awayTeam)
        {
            if (gameStatus.BallPosition > gameProperties.HalfFieldLength)
            {
                var shotOnGoalChance = homeTeam.ShotOnGoalRate * gameProperties.ShotAccuracyModifier;
                var isShotOnGoal = RandomService.GetRandomBetweenOneAndZero() <= shotOnGoalChance;
                var goalChance = homeTeam.AttackStrength / (homeTeam.AttackStrength + awayTeam.GoalKeeperStrength);
                var isKeeperBeat = RandomService.GetRandomBetweenOneAndZero() <= goalChance;
                gameResult.GoalEvents.Add(new GoalEvent
                {
                    Minute = gameStatus.Minute,
                    AddedTime = gameStatus.AddedMinutes,
                    IsShotOnGoal = isShotOnGoal,
                    IsGoal = isKeeperBeat && isShotOnGoal,
                    ActingTeam = ActingTeam.Home
                });
                gameStatus.BallPosition = 0;
            }
            else if (gameStatus.BallPosition < -gameProperties.HalfFieldLength)
            {
                var shotOnGoalChance = awayTeam.ShotOnGoalRate * gameProperties.ShotAccuracyModifier;
                var isShotOnGoal = RandomService.GetRandomBetweenOneAndZero() <= shotOnGoalChance;
                var goalChance = awayTeam.AttackStrength / (awayTeam.AttackStrength + homeTeam.GoalKeeperStrength);
                var isKeeperBeat = RandomService.GetRandomBetweenOneAndZero() <= goalChance;
                gameResult.GoalEvents.Add(new GoalEvent
                {
                    Minute = gameStatus.Minute,
                    AddedTime = gameStatus.AddedMinutes,
                    IsShotOnGoal = isShotOnGoal,
                    IsGoal = isKeeperBeat && isShotOnGoal,
                    ActingTeam = ActingTeam.Away
                });
                gameStatus.BallPosition = 0;
            }
        }
    }
}