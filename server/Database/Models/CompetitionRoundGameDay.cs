using System.Collections.Generic;

namespace Database.Models
{
    public class CompetitionRoundGameDay
    {
        public string Season { get; set; }
        public string CompetitionName { get; set; }
        public int RoundNumber { get; set; }
        public string GroupName { get; set; }
        public int GameDayNumber { get; set; }

        public CompetitionRoundGroup Group { get; set; }
        public ICollection<CompetitionRoundFixture> Fixtures { get; set; }
    }
}