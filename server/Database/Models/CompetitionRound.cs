﻿using System.Collections;
 using System.Collections.Generic;
 using Database.Enums;

namespace Database.Models
{
    public class CompetitionRound
    {
        public string Season { get; set; }
        public string CompetitionName { get; set; }
        public int Round { get; set; }
        public ReverseFixtureStructure ReverseFixtureStructure { get; set; }
        public ComparisonRule ComparisonRule { get; set; }

        public Competition Competition { get; set; }
        // TODO: Create CompetitionRoundTeam for many-to-many
        public ICollection<CompetitionRoundGroup> Groups { get; set; }

    }
}