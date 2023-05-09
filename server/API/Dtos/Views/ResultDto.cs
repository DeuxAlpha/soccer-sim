using System.Collections.Generic;
using System.Linq;
using Database.Models;

namespace API.Dtos.Views
{
    public class ResultDto
    {
        public string Score => $"{HomeGoals}:{AwayGoals}";
        public string HalfTimeScore => $"({HomeHalfGoals}:{AwayHalfGoals})";
        public string ShotsOnGoal => $"{HomeShotsOnGoal}:{AwayShotsOnGoal}";
        public string Shots => $"{HomeShots}:{AwayShots}";
        public string Possession => $"{HomePossession}%:{AwayPossession}%";
        public string Fixture => $"{HomeTeamName} - {AwayTeamName}";
        public int GameDay { get; set; }
        public IEnumerable<string> Story => GetEvents();
        public IEnumerable<LeagueFixtureEventDto> Events { private get; set; }
        public string HomeTeamName { get; set; }
        public int HomeGoals => Events.Count(e => e.EventTeamName == HomeTeamName && e.IsGoal);
        public int HomeHalfGoals => Events.Count(e => e.EventTeamName == HomeTeamName && e.IsGoal && e.Minute <= 45);
        public int HomeShots => Events.Count(e => e.EventTeamName == HomeTeamName);
        public int HomeShotsOnGoal => Events.Count(e => e.EventTeamName == HomeTeamName && e.IsShotOnGoal);
        public int HomePossession { get; set; }
        public string AwayTeamName { get; set; }
        public int AwayGoals => Events.Count(e => e.EventTeamName == AwayTeamName && e.IsGoal);
        public int AwayHalfGoals => Events.Count(e => e.EventTeamName == AwayTeamName && e.IsGoal && e.Minute <= 45);
        public int AwayShots => Events.Count(e => e.EventTeamName == AwayTeamName);
        public int AwayShotsOnGoal => Events.Count(e => e.EventTeamName == AwayTeamName && e.IsShotOnGoal);
        public int AwayPossession { get; set; }
        public string Winner => HomeGoals > AwayGoals ? HomeTeamName : AwayGoals > HomeGoals ? AwayTeamName : "Draw";
        public string Loser => HomeGoals < AwayGoals ? HomeTeamName : AwayGoals < HomeGoals ? AwayTeamName : "Draw";

        public ResultDto(LeagueFixture fixture)
        {
            HomeTeamName = fixture.HomeTeamName;
            AwayTeamName = fixture.AwayTeamName;
            Events = fixture.Events.Select(e => new LeagueFixtureEventDto(e));
            HomePossession = fixture.HomePossession ?? -1;
            AwayPossession = fixture.AwayPossession ?? -1;
            GameDay = fixture.GameDayNumber;
        }

        private IEnumerable<string> GetEvents()
        {
            return Events.Select(e =>
            {
                if (e.IsGoal)
                {
                    return e.AddedMinute == null || e.AddedMinute == 0
                        ? $"{e.EventTeamName} scores! {e.Minute}. Minute - {GetScoreAtMinute(e.Minute)}"
                        : $"{e.EventTeamName} scores! {e.Minute}. + {e.AddedMinute} Minute - {GetScoreAtMinute(e.Minute, (int) e.AddedMinute)}";
                }

                if (e.IsShotOnGoal)
                {
                    return e.AddedMinute == null || e.AddedMinute == 0
                        ? $"{e.EventTeamName} shot saved! {e.Minute}. Minute"
                        : $"{e.EventTeamName} shot saved! {e.Minute}. + {e.AddedMinute} Minute";
                }

                return e.AddedMinute == null || e.AddedMinute == 0
                    ? $"{e.EventTeamName} misses! {e.Minute}. Minute"
                    : $"{e.EventTeamName} misses! {e.Minute}. + {e.AddedMinute} Minute";
            });
        }

        public string GetScoreAtMinute(int minute)
        {
            var homeGoals = Events.Count(e => e.EventTeamName == HomeTeamName && e.IsGoal && e.Minute <= minute);
            var awayGoals = Events.Count(e => e.EventTeamName == AwayTeamName && e.IsGoal && e.Minute <= minute);
            return $"{homeGoals}:{awayGoals}";
        }

        public string GetScoreAtMinute(int minute, int addedMinute)
        {
            var homeGoals = Events.Count(e =>
                e.EventTeamName == HomeTeamName && e.IsGoal && e.Minute <= minute && e.AddedMinute <= addedMinute);
            var awayGoals = Events.Count(e =>
                e.EventTeamName == AwayTeamName && e.IsGoal && e.Minute <= minute && e.AddedMinute <= addedMinute);
            return $"{homeGoals}:{awayGoals}";
        }
    }
}