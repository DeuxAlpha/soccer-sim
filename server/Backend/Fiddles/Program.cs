using System;
using System.Collections.Generic;
using Domain.Models;
using Domain.Services;

namespace Fiddles
{
    class Program
    {
        static void Main(string[] args)
        {
            var results = new List<GameResult>
            {
                GameService.CalculateGame(new TeamLineUp {Strength = 1000}, new TeamLineUp {Strength = 900}),
                GameService.CalculateGame(new TeamLineUp {Strength = 800}, new TeamLineUp {Strength = 600}),
                GameService.CalculateGame(new TeamLineUp {Strength = 250}, new TeamLineUp {Strength = 150}),
                GameService.CalculateGame(new TeamLineUp {Strength = 1200}, new TeamLineUp {Strength = 600}),
                GameService.CalculateGame(new TeamLineUp {Strength = 600}, new TeamLineUp {Strength = 1200}),
                GameService.CalculateGame(new TeamLineUp {Strength = 1000}, new TeamLineUp {Strength = 1050}),
            };
            Console.WriteLine(results);
            foreach (var gameResult in results)
            {
                Console.WriteLine($"Strengths - {gameResult.HomeStrength}:{gameResult.AwayStrength}");
                foreach (var goalEvent in gameResult.GoalEvents)
                {
                    if (goalEvent.IsGoal)
                    {
                        Console.WriteLine(goalEvent.AddedTime == null || goalEvent.AddedTime == 0
                            ? $"{goalEvent.Team} scores! {goalEvent.Minute}. Minute - {gameResult.GetScoreAtMinute(goalEvent.Minute)}"
                            : $"{goalEvent.Team} scores! {goalEvent.Minute}. + {goalEvent.AddedTime} Minute - {gameResult.GetScoreAtMinute(goalEvent.Minute)}");
                    }
                    else
                    {
                        Console.WriteLine(goalEvent.AddedTime == null || goalEvent.AddedTime == 0
                            ? $"{goalEvent.Team} misses! {goalEvent.Minute}. Minute"
                            : $"{goalEvent.Team} misses! {goalEvent.Minute}. + {goalEvent.AddedTime} Minute");
                    }
                }

                Console.WriteLine($"Final result: {gameResult.HomeGoals}:{gameResult.AwayGoals} ({gameResult.HomeHalfTimeGoals}:{gameResult.AwayHalfTimeGoals})");
                Console.WriteLine($"Tot. chances: {gameResult.HomeChances}:{gameResult.AwayChances}");
            }
        }
    }
}