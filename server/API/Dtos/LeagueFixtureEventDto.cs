using Database.Models;
using Domain.Models;

namespace API.Dtos
{
    public class LeagueFixtureEventDto
    {
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string Season { get; set; }
        public string LeagueName { get; set; }
        public int GameDayNumber { get; set; }
        public int Minute { get; set; }
        public int? AddedMinute { get; set; }
        public bool IsGoal { get; set; }
        public bool IsShotOnGoal { get; set; }
        public string EventTeamName { get; set; }

        public LeagueFixtureEventDto(LeagueFixtureEvent fixtureEvent)
        {
            HomeTeamName = fixtureEvent.HomeTeamName;
            AwayTeamName = fixtureEvent.AwayTeamName;
            Season = fixtureEvent.Season;
            LeagueName = fixtureEvent.LeagueName;
            GameDayNumber = fixtureEvent.GameDayNumber;
            Minute = fixtureEvent.Minute;
            AddedMinute = fixtureEvent.AddedMinute;
            IsGoal = fixtureEvent.IsGoal;
            IsShotOnGoal = fixtureEvent.IsShotOnGoal;
            EventTeamName = fixtureEvent.EventTeamName;
        }
    }
}