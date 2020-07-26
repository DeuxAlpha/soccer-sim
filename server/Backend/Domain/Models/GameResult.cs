using System.Collections.Generic;
using System.Linq;
using Domain.Enums;

namespace Domain.Models
{
    public class GameResult
    {
        public List<GoalEvent> GoalEvents { get; }
        public double HomeStrength { get; set; }
        public double AwayStrength { get; set; }
        public int HomeGoals => GoalEvents.Count(e => e.Team == Team.Home && e.IsGoal);
        public int HomeHalfTimeGoals => GoalEvents.Count(e => e.Team == Team.Home && e.Minute <= 45 && e.IsGoal);
        public int HomeChances => GoalEvents.Count(e => e.Team == Team.Home);
        public int AwayGoals => GoalEvents.Count(e => e.Team == Team.Away && e.IsGoal);
        public int AwayHalfTimeGoals => GoalEvents.Count(e => e.Team == Team.Away && e.Minute <= 45);
        public int AwayChances => GoalEvents.Count(e => e.Team == Team.Away);

        public string GetScoreAtMinute(int minute)
        {
            var homeGoals = GoalEvents.Count(e => e.Team == Team.Home && e.IsGoal && e.Minute <= minute);
            var awayGoals = GoalEvents.Count(e => e.Team == Team.Away && e.IsGoal && e.Minute <= minute);
            return $"{homeGoals}:{awayGoals}";
        }

        public GameResult()
        {
            GoalEvents = new List<GoalEvent>();
        }
    }
}