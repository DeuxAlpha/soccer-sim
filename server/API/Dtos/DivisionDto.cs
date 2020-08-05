using System.Text.Json.Serialization;
using Database.Models;

namespace API.Dtos
{
    public class DivisionDto
    {
        public string Name { get; set; }
        public string Season { get; set; }
        public string Abbreviation { get; set; }
        public int Level { get; set; }
        public string CountryName { get; set; }

        public DivisionDto()
        {

        }

        public DivisionDto(Division division)
        {
            Name = division.Name;
            Season = division.Season;
            Abbreviation = division.Abbreviation;
            Level = division.Level;
            CountryName = division.CountryName;
        }

        public Division Map()
        {
            return new Division
            {
                Name = Name,
                Season = Season,
                Abbreviation = Abbreviation,
                Level = Level,
                CountryName = CountryName
            };
        }

        public void MapUpdate(Division division)
        {
            division.Abbreviation = Abbreviation;
            division.Level = Level;
            division.CountryName = CountryName;
        }
    }
}