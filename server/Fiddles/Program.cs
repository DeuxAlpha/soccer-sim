using System;
using System.Collections.Generic;
using Domain.Enums;
using Domain.Models;
using Domain.Services;

namespace Fiddles
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            CalculateResult_v1();
        }

        private static void CalculateResult_v1()
        {
            var homeTeam = new TeamLineUp
            {
                AttackStrength = 1200,
                DefenseStrength = 1000,
                GoalKeeperStrength = 1050,
                ShotOnGoalRate = 0.4,
                MaxPace = 35,
                PotentialPositiveShift = 25,
                PotentialPositiveShiftChance = 0.1,
                PotentialNegativeShift = 25,
                PotentialNegativeShiftChance = 0.125,
                CurrentForm = -50
            };
            var awayTeam = new TeamLineUp
            {
                AttackStrength = 350,
                DefenseStrength = 400,
                GoalKeeperStrength = 425,
                ShotOnGoalRate = 0.3,
                MaxPace = 60,
                PotentialPositiveShift = 30,
                PotentialPositiveShiftChance = 0.1,
                PotentialNegativeShift = 25,
                PotentialNegativeShiftChance = 0.025,
                CurrentForm = 125
            };
            var results = new List<GameResult>
            {
                GameService.CalculateGame_v1(
                    homeTeam,
                    awayTeam,
                    new GameProperties
                    {
                        ActionsPerMinute = 4,
                        MaxOvertime = 10,
                        HalfFieldLength = 100,
                        ShotAccuracyModifier = 1,
                        PaceModifier = 1,
                        MaxHomeAdvantage = 50,
                        MaxAwayDisadvantage = 100,
                        MaxProgressChance = 0.7,
                        MinProgressChance = 0.3
                    }),
            };
            Console.WriteLine(results);
            foreach (var gameResult in results)
            {
                foreach (var goalEvent in gameResult.GoalEvents)
                {
                    if (goalEvent.IsGoal)
                    {
                        Console.WriteLine(goalEvent.AddedTime == null || goalEvent.AddedTime == 0
                            ? $"{goalEvent.Team} scores! {goalEvent.Minute}. Minute - {gameResult.GetScoreAtMinute(goalEvent.Minute)}"
                            : $"{goalEvent.Team} scores! {goalEvent.Minute}. + {goalEvent.AddedTime} Minute - {gameResult.GetScoreAtMinute(goalEvent.Minute, (int) goalEvent.AddedTime)}");
                    }
                    else if (goalEvent.IsShotOnGoal)
                    {
                        Console.WriteLine(goalEvent.AddedTime == null || goalEvent.AddedTime == 0
                            ? $"{goalEvent.Team} shot saved! {goalEvent.Minute}. Minute"
                            : $"{goalEvent.Team} shot saved! {goalEvent.Minute}. + {goalEvent.AddedTime} Minute");
                    }
                    else
                    {
                        Console.WriteLine(goalEvent.AddedTime == null || goalEvent.AddedTime == 0
                            ? $"{goalEvent.Team} misses! {goalEvent.Minute}. Minute"
                            : $"{goalEvent.Team} misses! {goalEvent.Minute}. + {goalEvent.AddedTime} Minute");
                    }
                }

                Console.WriteLine(
                    $"Final result: {gameResult.HomeGoals}:{gameResult.AwayGoals} ({gameResult.HomeHalfTimeGoals}:{gameResult.AwayHalfTimeGoals})");
                Console.WriteLine($"Tot. shots on goal: {gameResult.HomeShotsOnGoal}:{gameResult.AwayShotsOnGoal}");
                Console.WriteLine($"Tot. chances: {gameResult.HomeChances}:{gameResult.AwayChances}");
                Console.WriteLine($"Possession: {gameResult.HomePossession * 100}%:{gameResult.AwayPossession * 100}%");
            }
        }

        private static void CalculateResult_v2()
        {
            var players = GetPlayers();
            var results = new List<GameResult>
            {
                GameService.CalculateGame_v2(new TeamLineUp
                {
                    Formation = GetFormation(0, 3, 4, 3)
                }, new TeamLineUp
                {
                    Formation = GetFormation(1, 3, 4, 4)
                }),
                GameService.CalculateGame_v2(new TeamLineUp
                {
                    Formation = GetFormation(0, 4, 4, 2)
                }, new TeamLineUp
                {
                    Formation = GetFormation(1, 3, 5, 1)
                })
            };
        }

        private static List<PlayerPosition> GetFormation(int teamIndex, int defenders, int midfielders, int attackers)
        {
            var formation = new List<PlayerPosition>();
            var players = GetPlayers();
            var playerOffset = 11 * teamIndex;
            for (var index = 0; index < 11; index++)
            {
                if (index < attackers)
                {
                    formation.Add(new PlayerPosition
                    {
                        Position = Position.Attack,
                        Player = players[index + playerOffset]
                    });
                }
                else if (index < attackers + midfielders)
                {
                    formation.Add(new PlayerPosition
                    {
                        Position = Position.Midfield,
                        Player = players[index + playerOffset]
                    });
                }
                else
                {
                    if (index + 1 == 11)
                    {
                        formation.Add(new PlayerPosition
                        {
                            Position = Position.Goal,
                            Player = players[11 + playerOffset]
                        });
                    }
                    else
                    {
                        formation.Add(new PlayerPosition
                        {
                            Position = Position.Defense,
                            Player = players[index + playerOffset]
                        });
                    }
                }
            }

            return formation;
        }

        private static List<Player> GetPlayers()
        {
            return new List<Player>
            {
                new Player
                {
                    Name = "Lionel Messi",
                    AttackingStrength = 99,
                    DefendingStrength = 80
                },
                new Player
                {
                    Name = "Antoine Griezmann",
                    AttackingStrength = 90,
                    DefendingStrength = 75
                },
                new Player
                {
                    Name = "Luis Suarez",
                    AttackingStrength = 95,
                    DefendingStrength = 60
                },
                new Player
                {
                    Name = "Arturo Vidal",
                    AttackingStrength = 80,
                    DefendingStrength = 80
                },
                new Player
                {
                    Name = "Frenkie de Jong",
                    AttackingStrength = 60,
                    DefendingStrength = 90
                },
                new Player
                {
                    Name = "Arthur",
                    AttackingStrength = 75,
                    DefendingStrength = 80
                },
                new Player
                {
                    Name = "Ivan Rakitic",
                    AttackingStrength = 70,
                    DefendingStrength = 70
                },
                new Player
                {
                    Name = "Gerard Pique",
                    AttackingStrength = 60,
                    DefendingStrength = 95
                },
                new Player
                {
                    Name = "Sergi Roberto",
                    AttackingStrength = 50,
                    DefendingStrength = 90
                },
                new Player
                {
                    Name = "Samuel Umtiti",
                    AttackingStrength = 60,
                    DefendingStrength = 85
                },
                new Player
                {
                    Name = "Marc-Andre ter Stegen",
                    AttackingStrength = 50,
                    DefendingStrength = 95
                },
                new Player
                {
                    Name = "Robert Lewandoski",
                    AttackingStrength = 98,
                    DefendingStrength = 50,
                },
                new Player
                {
                    Name = "Leroy Sane",
                    AttackingStrength = 97,
                    DefendingStrength = 45
                },
                new Player
                {
                    Name = "Thomas Muller",
                    AttackingStrength = 95,
                    DefendingStrength = 75
                },
                new Player
                {
                    Name = "Philippe Coutinho",
                    AttackingStrength = 90,
                    DefendingStrength = 85
                },
                new Player
                {
                    Name = "Leon Goretzka",
                    AttackingStrength = 85,
                    DefendingStrength = 82
                },
                new Player
                {
                    Name = "Kingsley Coman",
                    AttackingStrength = 82,
                    DefendingStrength = 78
                },
                new Player
                {
                    Name = "Serge Gnabry",
                    AttackingStrength = 88,
                    DefendingStrength = 80
                },
                new Player
                {
                    Name = "David Alaba",
                    AttackingStrength = 70,
                    DefendingStrength = 85
                },
                new Player
                {
                    Name = "Joshua Kimmich",
                    AttackingStrength = 75,
                    DefendingStrength = 95
                },
                new Player
                {
                    Name = "Benjamin Pavard",
                    AttackingStrength = 68,
                    DefendingStrength = 90
                },
                new Player
                {
                    Name = "Alphonso Davies",
                    AttackingStrength = 70,
                    DefendingStrength = 92
                },
                new Player
                {
                    Name = "Manuel Neuer",
                    AttackingStrength = 80,
                    DefendingStrength = 95
                }
            };
        }
    }
}