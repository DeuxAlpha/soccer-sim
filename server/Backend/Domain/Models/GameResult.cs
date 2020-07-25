using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Enums;

namespace Domain.Models
{
    public class GameResult
    {
        public IEnumerable<GoalEvent> GoalEvents { get; set; }
        public int HomeGoals => GoalEvents.Count(e => e.Team == Team.Home);
        public int HomeHalfTimeGoals => GoalEvents.Count(e => e.Team == Team.Home && e.Minute <= 45);
        public int AwayGoals => GoalEvents.Count(e => e.Team == Team.Away);
        public int AwayHalfTimeGoals => GoalEvents.Count(e => e.Team == Team.Away && e.Minute <= 45);
    }
}