using System.Collections.Generic;
using Database.Models.Shared;

namespace Database.Models
{
    public class LeagueFixture : BaseFixture
    {
        public string Season { get; set; }
        public string LeagueName { get; set; }
        public int GameDayNumber { get; set; }

        public League League { get; set; }
        public LeagueGameDay GameDay { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public ICollection<LeagueFixtureEvent> Events { get; set; }
    }
}