using Database.Models.Shared;

namespace Database.Models
{
    public class LeagueFixtureEvent : BaseGameEvent
    {
        public string LeagueName { get; set; }
        public string Season { get; set; }
        public int GameDayNumber { get; set; }
        public Team EventTeam { get; set; }
        public LeagueFixture Fixture { get; set; }
        
        public LeagueFixtureEvent() {}
    }
}