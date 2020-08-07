namespace Database.Models.Shared
{
    public abstract class BaseGameEvent
    {
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public int Minute { get; set; }
        public int? AddedMinute { get; set; }
        public bool IsGoal { get; set; }
        public bool IsShotOnGoal { get; set; }
        public string EventTeamName { get; set; }
    }
}