using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Enums;

namespace Domain.Models
{
    public class GameResult
    {
        public List<GoalEvent> GoalEvents { get; }
        public List<Team> Possessions { get; set; }
        public double HomePossession => Math.Round((double) Possessions.Count(p => p == Team.Home) / Possessions.Count, 2);
        public double AwayPossession => Math.Round((double) Possessions.Count(p => p == Team.Away) / Possessions.Count, 2);
        public int HomeGoals => GoalEvents.Count(e => e.Team == Team.Home && e.IsGoal);
        public int HomeHalfTimeGoals => GoalEvents.Count(e => e.Team == Team.Home && e.Minute <= 45 && e.IsGoal);
        public int HomeShotsOnGoal => GoalEvents.Count(e => e.Team == Team.Home && e.IsShotOnGoal);
        public int HomeChances => GoalEvents.Count(e => e.Team == Team.Home);
        public int AwayGoals => GoalEvents.Count(e => e.Team == Team.Away && e.IsGoal);
        public int AwayHalfTimeGoals => GoalEvents.Count(e => e.Team == Team.Away && e.Minute <= 45 && e.IsGoal);
        public int AwayShotsOnGoal => GoalEvents.Count(e => e.Team == Team.Away && e.IsShotOnGoal);
        public int AwayChances => GoalEvents.Count(e => e.Team == Team.Away);

        public string GetScoreAtMinute(int minute)
        {
            var homeGoals = GoalEvents.Count(e => e.Team == Team.Home && e.IsGoal && e.Minute <= minute);
            var awayGoals = GoalEvents.Count(e => e.Team == Team.Away && e.IsGoal && e.Minute <= minute);
            return $"{homeGoals}:{awayGoals}";
        }

        public string GetScoreAtMinute(int minute, int addedMinute)
        {
            var homeGoals = GoalEvents.Count(e => e.Team == Team.Home && e.IsGoal && e.Minute <= minute && e.AddedTime <= addedMinute);
            var awayGoals = GoalEvents.Count(e => e.Team == Team.Away && e.IsGoal && e.Minute <= minute && e.AddedTime <= addedMinute);
            return $"{homeGoals}:{awayGoals}";
        }

        public GameResult()
        {
            GoalEvents = new List<GoalEvent>();
            Possessions = new List<Team>();
        }
    }
}