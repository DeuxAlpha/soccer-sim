using System.Collections;
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
        public ICollection<Competition> Competitions { get; set; }
        public Division Division { get; set; }
        public PromotionSystem PromotionSystem { get; set; }
        
        public League() {}

        public League(League league)
        {
            // Assign values from league to this
            Season = league.Season;
            Name = league.Name;
            Abbreviation = league.Abbreviation;
            Rounds = league.Rounds;
            DivisionName = league.DivisionName;
            Image = league.Image;
            ShotAccuracyModifier = league.ShotAccuracyModifier;
            PaceModifier = league.PaceModifier;
            MaxHomeAdvantage = league.MaxHomeAdvantage;
            MaxAwayDisadvantage = league.MaxAwayDisadvantage;
            MaxProgressChance = league.MaxProgressChance;
            MinProgressChance = league.MinProgressChance;
            ActionsPerMinute = league.ActionsPerMinute;
        }
    }
}