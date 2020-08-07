using System.Collections.Generic;
using Database.Enums;
using Database.Models.Shared;

namespace Database.Models
{
    public class League : BaseTournament
    {
        public string Season { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int Rounds { get; set; }
        public string DivisionName { get; set; }
        public string Image { get; set; }

        public ICollection<Team> Teams { get; set; }
        public ICollection<LeagueGameDay> GameDays { get; set; }
        public ICollection<LeagueFixture> LeagueFixtures { get; set; }
        public Division Division { get; set; }
        public PromotionSystem PromotionSystem { get; set; }
    }
}