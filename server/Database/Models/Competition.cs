using System.Collections.Generic;
using Database.Enums;

namespace Database.Models
{
    public class Competition
    {
        public string Year { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public double ShotAccuracyModifier { get; set; }
        public double PaceModifier { get; set; }
        public double MaxHomeAdvantage { get; set; }
        public double MaxAwayDisadvantage { get; set; }
        public CompetitionType CompetitionType { get; set; }
        public string CountryName { get; set; }

        public ICollection<TeamCompetition> Teams { get; set; }
        public Country Country { get; set; }
    }
}