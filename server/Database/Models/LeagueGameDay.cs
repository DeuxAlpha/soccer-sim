using System.Collections.Generic;

namespace Database.Models
{
    public class LeagueGameDay
    {
        public string Season { get; set; }
        public string LeagueName { get; set; }
        public int GameDayNumber { get; set; }

        public League League { get; set; }
        public ICollection<LeagueFixture> Fixtures { get; set; }
    }
}