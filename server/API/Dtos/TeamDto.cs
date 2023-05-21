using System.Collections.Generic;
using Database.Models;

namespace API.Dtos
{
    public class TeamDto
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
        public string LeagueName { get; set; }
        public string Image { get; set; }
        public bool PromotionFlag { get; set; }
        public bool RelegationFlag { get; set; }
        public bool ChampionFlag { get; set; }

        public TeamDto()
        {

        }
        public TeamDto(Team team)
        {
            Season = team.Season;
            Name = team.Name;
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
            PromotionFlag = team.PromotionFlag;
            RelegationFlag = team.RelegationFlag;
            ChampionFlag = team.ChampionFlag;
        }
        
        public Team Map()
        {
            return new Team
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
                LeagueName = LeagueName,
                Image = Image,
                PromotionFlag = PromotionFlag,
                RelegationFlag = RelegationFlag,
                ChampionFlag = ChampionFlag
            };
        }

        public void MapUpdate(Team team)
        {
            team.Abbreviation = Abbreviation;
            team.AttackStrength = AttackStrength;
            team.DefenseStrength = DefenseStrength;
            team.GoalieStrength = GoalieStrength;
            team.PotentialPositiveShift = PotentialPositiveShift;
            team.PotentialPositiveChance = PotentialPositiveChance;
            team.PotentialNegativeShift = PotentialNegativeShift;
            team.PotentialNegativeChance = PotentialNegativeChance;
            team.MaxPace = MaxPace;
            team.ShotOnGoalRate = ShotOnGoalRate;
            team.LeagueName = LeagueName;
            team.Image = Image;
            team.PromotionFlag = PromotionFlag;
            team.RelegationFlag = RelegationFlag;
            team.ChampionFlag = ChampionFlag;
        }
    }
}