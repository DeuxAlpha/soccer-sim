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
                strengthRequest.StrengthVariance);

            var winners = Variable.Array<int>(game);
            var losers = Variable.Array<int>(game);
            
            using (Variable.ForEach(game))
            {
                var winnerPerformance = Variable.GaussianFromMeanAndVariance(playerSkills[winners[game]], 1.0);
                var loserPerformance = Variable.GaussianFromMeanAndVariance(playerSkills[losers[game]], 1.0);

                Variable.ConstrainTrue(winnerPerformance > loserPerformance);
            }

            winners.ObservedValue = winnerData;
            losers.ObservedValue = loserData;

            var inferenceEngine = new InferenceEngine();
            var inferredSkills = inferenceEngine.Infer<Gaussian[]>(playerSkills);

            var orderedSkills = inferredSkills
                .Select((skill, index) => new { Team = index, Skill = skill.GetMean() })
                .OrderByDescending(teamSkill => teamSkill.Skill);

            var dictionary = orderedSkills
                .ToDictionary(
                    orderedSkill => orderedSkill.Team, 
                    orderedSkill => orderedSkill.Skill);
            return new StrengthResponse{
                IdToStrengthsDictionary = dictionary
            };
        }
    }

    public struct StrengthRequest
    {
        public double AverageStrength;
        public double StrengthVariance;
        public IEnumerable<int> WinnerIds;
        public IEnumerable<int> LoserIds;
    }

    public struct StrengthResponse
    {
        public Dictionary<int, double> IdToStrengthsDictionary;
    }
}