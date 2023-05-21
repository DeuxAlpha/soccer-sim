using System;

namespace API.Dtos.Views.Table
{
    public class TablePositionDto
    {
        public string TeamName { get; set; }
        public int Position { get; set; }
        public int Points => Wins * 3 + Draws * 1;
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference => GoalsFor - GoalsAgainst;
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int Games => Wins + Draws + Losses;
        public int Shots { get; set; }
        public int ShotsOnGoal { get; set; }
        public int ShotsAgainst { get; set; }
        public int ShotsAgainstGoal { get; set; }
        public double AttackStrength { get; set; }
        public double DefenseStrength { get; set; }
        public double GoalieStrength { get; set; }
        public double AverageStrength => (AttackStrength + DefenseStrength + GoalieStrength) / 3;
        public bool ChampionFlag { get; set; }
        public bool PromotionFlag { get; set; }
        public bool RelegationFlag { get; set; }

        public TablePositionDto Clone()
        {
            return new TablePositionDto
            {
                TeamName = TeamName,
                Position = Position,
                GoalsFor = GoalsFor,
                GoalsAgainst = GoalsAgainst,
                Wins = Wins,
                Draws = Draws,
                Losses = Losses,
                Shots = Shots,
                ShotsOnGoal = ShotsOnGoal,
                ShotsAgainst = ShotsAgainst,
                ShotsAgainstGoal = ShotsAgainstGoal,
                AttackStrength = AttackStrength,
                DefenseStrength = DefenseStrength,
                GoalieStrength = GoalieStrength,
                ChampionFlag = ChampionFlag,
                PromotionFlag = PromotionFlag,
                RelegationFlag = RelegationFlag
            };
        }
    }
}