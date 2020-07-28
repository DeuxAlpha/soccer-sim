using Database.Models;

namespace API.Dtos
{
    public class ContinentDto
    {
        public string Season { get; set; }
        public string Name { get; set; }

        public ContinentDto(){}
        public ContinentDto(Continent continent)
        {
            Season = continent.Season;
            Name = continent.Name;
        }

        public Continent Map()
        {
            return new Continent
            {
                Season = Season,
                Name = Name
            };
        }
    }
}