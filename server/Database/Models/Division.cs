using System.Collections;
using System.Collections.Generic;

namespace Database.Models
{
    public class Division
    {
        public string Name { get; set; }
        public string Season { get; set; }
        public string Abbreviation { get; set; }
        public int Level { get; set; }
        public string CountryName { get; set; }
        public bool OnlyFirstTeams { get; set; }

        public Country Country { get; set; }
        public ICollection<League> Leagues { get; set; }
    }
}