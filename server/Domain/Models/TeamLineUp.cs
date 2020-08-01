using System.Collections.Generic;
using Domain.Services;

namespace Domain.Models
{
    public class TeamLineUp
    {
        public List<PlayerPosition> Formation { get; set; }
        public double AttackStrength { get; set; }
        public double DefenseStrength { get; set; }
        public double GoalKeeperStrength { get; set; }
        public double PotentialPositiveShift { get; set; }
        public double PotentialPositiveShiftChance { get; set; }
        public double PotentialNegativeShift { get; set; }
        public double PotentialNegativeShiftChance { get; set; }
        public double CurrentForm { get; set; }
        public int MaxPace { get; set; }
        public double ShotOnGoalRate { get; set; }

        public void ApplyPotentialShift()
        {
            if (RandomService.GetRandomBetweenOneAndZero() <= PotentialPositiveShiftChance)
            {
                AttackStrength += RandomService.GetRandomNumber(0, PotentialPositiveShift);
            }

            if (RandomService.GetRandomBetweenOneAndZero() <= PotentialPositiveShiftChance)
            {
                DefenseStrength += RandomService.GetRandomNumber(0, PotentialPositiveShift);
            }

            if (RandomService.GetRandomBetweenOneAndZero() <= PotentialNegativeShiftChance)
            {
                AttackStrength -= RandomService.GetRandomNumber(0, PotentialNegativeShift);
            }

            if (RandomService.GetRandomBetweenOneAndZero() <= PotentialNegativeShiftChance)
            {
                DefenseStrength -= RandomService.GetRandomNumber(0, PotentialNegativeShift);
            }
        }

        public TeamLineUp Clone()
        {
            return new TeamLineUp
            {
                AttackStrength = AttackStrength,
                DefenseStrength = DefenseStrength,
                GoalKeeperStrength = GoalKeeperStrength,
                PotentialPositiveShift = PotentialPositiveShift,
                PotentialPositiveShiftChance = PotentialPositiveShiftChance,
                PotentialNegativeShift = PotentialNegativeShift,
                PotentialNegativeShiftChance = PotentialNegativeShiftChance,
                CurrentForm = CurrentForm,
                MaxPace = MaxPace,
                ShotOnGoalRate = ShotOnGoalRate,
            };
        }
    }
}