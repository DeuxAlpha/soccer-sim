﻿using System.Collections.Generic;
using Database.Enums;

namespace Database.Models
{
    public class League
    {
        public string Season { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public double ShotAccuracyModifier { get; set; }
        public double PaceModifier { get; set; }
        public double MaxHomeAdvantage { get; set; }
        public double MaxAwayDisadvantage { get; set; }
        public int ActionsPerMinute { get; set; }
        public double MaxProgressChance { get; set; }
        public double MinProgressChance { get; set; }
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