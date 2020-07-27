using System.Collections.Generic;

namespace Database.Models
{
    public class Continent
    {
        public string Year { get; set; }
        public string Name { get; set; }
        public ICollection<Country> Countries { get; set; }
    }
}