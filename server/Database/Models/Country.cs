﻿using System.Collections;
using System.Collections.Generic;

namespace Database.Models
{
    public class Country
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

        public ICollection<Division> Divisions { get; set; }
        public ICollection<Competition> Competitions { get; set; }
        public Continent Continent { get; set; }
        
        public Country() {}

        public Country(Country country)
        {
            // Assing values from country to this
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
    }
}