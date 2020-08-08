using System.Collections;
using System.Collections.Generic;
using Database.Enums;
using Database.Models.Shared;

namespace Database.Models
{
    public class Competition : BaseTournament
    {
        public string Season { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public CompetitionType CompetitionType { get; set; }
        /// <summary>If true, no home advantages or away disadvantages are being applied.</summary>
        public bool TournamentOnNeutralGrounds { get; set; }

        public string ContinentName { get; set; }
        public string CountryName { get; set; }
        public string DivisionName { get; set; }
        public string LeagueName { get; set; }

        public Continent Continent { get; set; }
        public Country Country { get; set; }
        public Division Division { get; set; }
        public League League { get; set; }
        // TODO: Create CompetitionTeam to hold many-to-many
        public ICollection<CompetitionRound> Rounds { get; set; }
        public ICollection<CompetitionRoundFixture> Fixtures { get; set; }
    }
}