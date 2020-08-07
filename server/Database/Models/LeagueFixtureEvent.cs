using Database.Models.Shared;

namespace Database.Models
{
    public class LeagueFixtureEvent : GameEvent
    {
        public string LeagueName { get; set; }
        public Team EventTeam { get; set; }
        public LeagueFixture LeagueFixture { get; set; }
    }
}