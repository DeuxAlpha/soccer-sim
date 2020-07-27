﻿using System.Collections.Generic;
using Database.Models;

namespace API.Dtos
{
    public class TeamDto
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

        public TeamDto(Team team)
        {
            Year = team.Year;
            Name = team.Name;
            ShortName = team.ShortName;
            Abbreviation = team.Abbreviation;
            AttackStrength = team.AttackStrength;
            DefenseStrength = team.DefenseStrength;
            GoalieStrength = team.GoalieStrength;
            PotentialPositiveShift = team.PotentialPositiveShift;
            PotentialPositiveChance = team.PotentialPositiveChance;
            PotentialNegativeShift = team.PotentialNegativeShift;
            PotentialNegativeChance = team.PotentialNegativeChance;
            MaxPace = team.MaxPace;
            ShotOnGoalRate = team.ShotOnGoalRate;
            LeagueName = team.LeagueName;
            Image = team.Image;
        }
    }
}