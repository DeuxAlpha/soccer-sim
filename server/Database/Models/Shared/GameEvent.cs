namespace Database.Models.Shared
{
    public class GameEvent
    {
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string Season { get; set; }
        public int GameDayNumber { get; set; }
        public int Minute { get; set; }
        public int? AddedMinute { get; set; }
        public bool IsGoal { get; set; }
        public bool IsShotOnGoal { get; set; }
        public string EventTeamName { get; set; }
    }
}