using Database.Models.Shared;

namespace Database.Models
{
    public class CompetitionRoundFixtureEvent : BaseGameEvent
    {
        public string Season { get; set; }
        public string CompetitionName { get; set; }
        public int RoundNumber { get; set; }
        public string GroupName { get; set; }
        public int GameDayNumber { get; set; }

        public Team EventTeam { get; set; }
        public CompetitionRoundFixture Fixture { get; set; }
    }
}