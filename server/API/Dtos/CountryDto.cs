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
        public double CountryStrengthModifier { get; set; }
        public string ContinentName { get; set; }
        public string Image { get; set; }

        public CountryDto()
        {
        }

        public CountryDto(Country country)
        {
        }

        public Country Map()
        {
            return new Country
            {

            };
        }
    }
}