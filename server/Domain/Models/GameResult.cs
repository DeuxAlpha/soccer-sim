using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Enums;

namespace Domain.Models
{
    public class GameResult
    {
        public List<GoalEvent> GoalEvents { get; set; }
        public List<ActingTeam> Possessions { get; set; }
        public TeamLineUp PreHomeTeam { get; set; }
        public TeamLineUp PreAwayTeam { get; set; }
        public TeamLineUp PostHomeTeam { get; set; }
        public TeamLineUp PostAwayTeam { get; set; }
        public double HomePossession => Math.Round((double) Possessions.Count(p => p == ActingTeam.Home) / Possessions.Count, 2);
        public double AwayPossession => Math.Round((double) Possessions.Count(p => p == ActingTeam.Away) / Possessions.Count, 2);
        public int HomeGoals => GoalEvents.Count(e => e.ActingTeam == ActingTeam.Home && e.IsGoal);
        public int HomeHalfTimeGoals => GoalEvents.Count(e => e.ActingTeam == ActingTeam.Home && e.Minute <= 45 && e.IsGoal);
        public int HomeShotsOnGoal => GoalEvents.Count(e => e.ActingTeam == ActingTeam.Home && e.IsShotOnGoal);
        public int HomeChances => GoalEvents.Count(e => e.ActingTeam == ActingTeam.Home);
        public int AwayGoals => GoalEvents.Count(e => e.ActingTeam == ActingTeam.Away && e.IsGoal);
        public int AwayHalfTimeGoals => GoalEvents.Count(e => e.ActingTeam == ActingTeam.Away && e.Minute <= 45 && e.IsGoal);
        public int AwayShotsOnGoal => GoalEvents.Count(e => e.ActingTeam == ActingTeam.Away && e.IsShotOnGoal);
        public int AwayChances => GoalEvents.Count(e => e.ActingTeam == ActingTeam.Away);

        public string GetScoreAtMinute(int minute)
        {
            var homeGoals = GoalEvents.Count(e => e.ActingTeam == ActingTeam.Home && e.IsGoal && e.Minute <= minute);
            var awayGoals = GoalEvents.Count(e => e.ActingTeam == ActingTeam.Away && e.IsGoal && e.Minute <= minute);
            return $"{homeGoals}:{awayGoals}";
        }

        public string GetScoreAtMinute(int minute, int addedMinute)
        {
            var homeGoals = GoalEvents.Count(e => e.ActingTeam == ActingTeam.Home && e.IsGoal && e.Minute <= minute && e.AddedTime <= addedMinute);
            var awayGoals = GoalEvents.Count(e => e.ActingTeam == ActingTeam.Away && e.IsGoal && e.Minute <= minute && e.AddedTime <= addedMinute);
            return $"{homeGoals}:{awayGoals}";
        }

        public GameResult()
        {
            GoalEvents = new List<GoalEvent>();
            Possessions = new List<ActingTeam>();
        }
    }
}