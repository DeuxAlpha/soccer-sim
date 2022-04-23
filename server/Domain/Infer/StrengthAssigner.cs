using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ML.Probabilistic.Distributions;
using Microsoft.ML.Probabilistic.Models;
using Range = Microsoft.ML.Probabilistic.Models.Range;

namespace Domain.Infer
{
    public static class StrengthAssigner
    {
        public static StrengthResponse AssignStrengths(StrengthRequest strengthRequest)
        {
            var winnerData = strengthRequest.WinnerIds.ToArray();
            var loserData = strengthRequest.LoserIds.ToArray();

            var game = new Range(winnerData.Length);
            var player = new Range(winnerData.Concat(loserData).Max() + 1);

            var playerSkills = Variable.Array<double>(player);
            playerSkills[player] = Variable.GaussianFromMeanAndVariance(
                    strengthRequest.AverageStrength,
                    strengthRequest.StrengthVariance * 100.0)
                .ForEach(player);

            var winners = Variable.Array<int>(game);
            var losers = Variable.Array<int>(game);
            
            using (Variable.ForEach(game))
            {
                var impact = strengthRequest.StrengthVariance * 10.0;
                var winnerPerformance = Variable.GaussianFromMeanAndVariance(playerSkills[winners[game]], impact);
                var loserPerformance = Variable.GaussianFromMeanAndVariance(playerSkills[losers[game]], impact);

                Variable.ConstrainTrue(winnerPerformance > loserPerformance);
            }

            winners.ObservedValue = winnerData;
            losers.ObservedValue = loserData;

            var inferenceEngine = new InferenceEngine();
            var inferredSkills = inferenceEngine.Infer<Gaussian[]>(playerSkills);

            var orderedSkills = inferredSkills
                .Select((skill, index) => new { TeamId = index, Skill = skill })
                .OrderByDescending(teamSkill => teamSkill.Skill.GetMean())
                .ToList();

            foreach (var orderedSkill in orderedSkills)
            {
                Console.WriteLine($"Team {orderedSkill.TeamId} with skill {orderedSkill.Skill}");
            }

            var dictionary = orderedSkills
                .ToDictionary(
                    orderedSkill => orderedSkill.TeamId, 
                    orderedSkill => orderedSkill.Skill);
            return new StrengthResponse{
                IdToStrengthsDictionary = dictionary
            };
        }
    }

    public class StrengthRequest
    {
        public double AverageStrength { get; set; } = 600.0;
        public double StrengthVariance { get; set; } = 100.0;
        public IEnumerable<int> WinnerIds;
        public IEnumerable<int> LoserIds;
    }

    public struct StrengthResponse
    {
        public Dictionary<int, Gaussian> IdToStrengthsDictionary;
    }
}