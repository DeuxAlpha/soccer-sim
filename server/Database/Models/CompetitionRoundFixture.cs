using System.Collections;
using System.Collections.Generic;
using Database.Models.Shared;

namespace Database.Models
{
    public class CompetitionRoundFixture : BaseFixture
    {
        public string Season { get; set; }
        public string CompetitionName { get; set; }
        public int RoundNumber { get; set; }
        public string GroupName { get; set; }
        public int GameDayNumber { get; set; }

        public Competition Competition { get; set; }
        public CompetitionRoundGameDay GameDay { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public ICollection<CompetitionRoundFixtureEvent> Events { get; set; }
    }
}