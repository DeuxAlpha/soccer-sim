namespace Database.Models
{
    public class TeamCompetition
    {
        public string Year { get; set; }
        public string TeamName { get; set; }
        public string CompetitionName { get; set; }
        public Team Team { get; set; }
        public Competition Competition { get; set; }
    }
}