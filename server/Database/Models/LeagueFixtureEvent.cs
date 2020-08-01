namespace Database.Models
{
    public class LeagueFixtureEvent
    {
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string Season { get; set; }
        public string LeagueName { get; set; }
        public int GameDayNumber { get; set; }
        public int Minute { get; set; }
        public int? AddedMinute { get; set; }
        public bool IsGoal { get; set; }
        public bool IsShotOnGoal { get; set; }
        public string EventTeamName { get; set; }
        public Team EventTeam { get; set; }
        public LeagueFixture LeagueFixture { get; set; }
    }
}