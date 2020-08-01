using System.Collections.Generic;
using System.Linq;
using Domain.Enums;

namespace Domain.Models
{
    public class PenaltiesResult
    {
        public List<PenaltyEvent> PenaltyEvents { get; }
        public int HomeGoals => PenaltyEvents.Count(e => e.ActingTeam == ActingTeam.Home && e.IsGoal);
        public int HomeTries => PenaltyEvents.Count(e => e.ActingTeam == ActingTeam.Home);
        public int AwayGoals => PenaltyEvents.Count(e => e.ActingTeam == ActingTeam.Away && e.IsGoal);
        public int AwayTries => PenaltyEvents.Count(e => e.ActingTeam == ActingTeam.Away);
        public int OverallTries => PenaltyEvents.Count;

        public PenaltiesResult()
        {
            PenaltyEvents = new List<PenaltyEvent>();
        }
    }
}