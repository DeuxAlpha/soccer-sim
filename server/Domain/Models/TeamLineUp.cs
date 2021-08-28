using System.Collections.Generic;
using Domain.Services;

namespace Domain.Models
{
    public class TeamLineUp
    {
        public List<PlayerPosition> Formation { get; set; }
        public double AttackStrength { get; set; } = 600;
        public double DefenseStrength { get; set; } = 600;
        public double GoalKeeperStrength { get; set; } = 600;
        public double PotentialPositiveShift { get; set; } = 10;
        public double PotentialPositiveShiftChance { get; set; } = 0.1;
        public double PotentialNegativeShift { get; set; } = 10;
        public double PotentialNegativeShiftChance { get; set; } = 0.1;
        public double CurrentForm { get; set; } = 0;
        public int MaxPace { get; set; } = 30;
        public double ShotOnGoalRate { get; set; } = 0.3;

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