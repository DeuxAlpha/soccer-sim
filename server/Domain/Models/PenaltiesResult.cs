using System.Collections.Generic;
using System.Linq;
using Domain.Enums;

namespace Domain.Models
{
    public class PenaltiesResult
    {
        public List<PenaltyEvent> PenaltyEvents { get; }
        public int HomeGoals => PenaltyEvents.Count(e => e.Team == Team.Home && e.IsGoal);
        public int HomeTries => PenaltyEvents.Count(e => e.Team == Team.Home);
        public int AwayGoals => PenaltyEvents.Count(e => e.Team == Team.Away && e.IsGoal);
        public int AwayTries => PenaltyEvents.Count(e => e.Team == Team.Away);
        public int OverallTries => PenaltyEvents.Count;

        public PenaltiesResult()
        {
            PenaltyEvents = new List<PenaltyEvent>();
        }
    }
}