using System.Collections.Generic;

namespace Database.Models
{
    public class Team
    {
        public string Year { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Abbreviation { get; set; }
        public double AttackStrength { get; set; }
        public double DefenseStrength { get; set; }
        public double GoalieStrength { get; set; }
        public double PotentialPositiveShift { get; set; }
        public double PotentialPositiveChance { get; set; }
        public double PotentialNegativeShift { get; set; }
        public double PotentialNegativeChance { get; set; }
        public int MaxPace { get; set; }
        public double ShotOnGoalRate { get; set; }
        public string LeagueName { get; set; }
        public string Image { get; set; }

        public League League { get; set; }
        public ICollection<LeagueFixture> HomeLeagueFixtures { get; set; }
        public ICollection<LeagueFixture> AwayLeagueFixtures { get; set; }
    }
}