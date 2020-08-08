using System.Collections;
using System.Collections.Generic;

namespace Database.Models
{
    public class CompetitionRoundGroup
    {
        public string Season { get; set; }
        public string CompetitionName { get; set; }
        public int RoundNumber { get; set; }
        public string GroupName { get; set; }
        /// <summary>The amount of times opponents should play against each other.</summary>
        public int Rounds { get; set; }

        public CompetitionRound Round { get; set; }
        // TODO: Create CompetitionGroupTeam for many-to-many
        public ICollection<CompetitionRoundGameDay> GameDays { get; set; }
    }
}