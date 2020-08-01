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
    }
}