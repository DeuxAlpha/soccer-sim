using Domain.Enums;

namespace Domain.Models
{
    public class GoalEvent
    {
        public int Minute { get; set; }
        public int? AddedTime { get; set; }
        public bool IsGoal { get; set; }
        public Player Player { get; set; }
        public Team Team { get; set; }
    }
}