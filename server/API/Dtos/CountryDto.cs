using Database.Models;

namespace API.Dtos
{
    public class CountryDto
    {
        public string Season { get; set; }
        public string Name { get; set; }
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
        public string ContinentName { get; set; }
        public string Image { get; set; }

        public CountryDto()
        {
        }

        public CountryDto(Country country)
        {
            Season = country.Season;
            Name = country.Name;
            Abbreviation = country.Abbreviation;
            AttackStrength = country.AttackStrength;
            DefenseStrength = country.DefenseStrength;
            GoalieStrength = country.GoalieStrength;
            PotentialPositiveShift = country.PotentialPositiveShift;
            PotentialPositiveChance = country.PotentialPositiveChance;
            PotentialNegativeShift = country.PotentialNegativeShift;
            PotentialNegativeChance = country.PotentialNegativeChance;
            MaxPace = country.MaxPace;
            ShotOnGoalRate = country.ShotOnGoalRate;
            ContinentName = country.ContinentName;
            Image = country.Image;
        }

        public Country Map()
        {
            return new Country
            {
                Season = Season,
                Name = Name,
                Abbreviation = Abbreviation,
                AttackStrength = AttackStrength,
                DefenseStrength = DefenseStrength,
                GoalieStrength = GoalieStrength,
                PotentialPositiveShift = PotentialPositiveShift,
                PotentialPositiveChance = PotentialPositiveChance,
                PotentialNegativeShift = PotentialNegativeShift,
                PotentialNegativeChance = PotentialNegativeChance,
                MaxPace = MaxPace,
                ShotOnGoalRate = ShotOnGoalRate,
                ContinentName = ContinentName,
                Image = Image
            };
        }

        public void MapUpdate(Country country)
        {
            country.Abbreviation = Abbreviation;
            country.AttackStrength = AttackStrength;
            country.DefenseStrength = DefenseStrength;
            country.GoalieStrength = GoalieStrength;
            country.PotentialPositiveShift = PotentialPositiveShift;
            country.PotentialPositiveChance = PotentialPositiveChance;
            country.PotentialNegativeShift = PotentialNegativeShift;
            country.PotentialNegativeChance = PotentialNegativeChance;
            country.MaxPace = MaxPace;
            country.ShotOnGoalRate = ShotOnGoalRate;
            country.ContinentName = ContinentName;
            country.Image = Image;
        }
    }
}