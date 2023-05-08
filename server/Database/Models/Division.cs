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
        public ICollection<Competition> Competitions { get; set; }
        
        public Division() {}

        public Division(Division division)
        {
            // Assign all properties from the division to this division.
            Name = division.Name;
            Season = division.Season;
            Abbreviation = division.Abbreviation;
            Level = division.Level;
            CountryName = division.CountryName;
            OnlyFirstTeams = division.OnlyFirstTeams;
            
        }
    }
}