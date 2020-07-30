namespace Database.Models
{
    public class LeagueFixture
    {
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string Season { get; set; }
        public string LeagueName { get; set; }
        public int GameDayNumber { get; set; }

        public int HalfFieldLength { get; set; }
        public int ActionsPerMinute { get; set; }
        public int MaxOvertime { get; set; }
        public double ShotAccuracyModifier { get; set; }
        public double PaceModifier { get; set; }
        public double MaxHomeAdvantage { get; set; }
        public double MaxAwayDisadvantage { get; set; }

        public double? HomeAttackStrength { get; set; }
        public double? HomeDefenseStrength { get; set; }
        public double? HomeGoalKeeperStrength { get; set; }
        public double? HomePotentialPositiveShift { get; set; }
        public double? HomePotentialPositiveChance { get; set; }
        public double? HomePotentialNegativeShift { get; set; }
        public double? HomePotentialNegativeChance { get; set; }
        public int? HomeMaxPace { get; set; }
        public double? HomeShotOnGoalRate { get; set; }
        public double? AwayAttackStrength { get; set; }
        public double? AwayDefenseStrength { get; set; }
        public double? AwayGoalKeeperStrength { get; set; }
        public double? AwayPotentialPositiveShift { get; set; }
        public double? AwayPotentialPositiveChance { get; set; }
        public double? AwayPotentialNegativeShift { get; set; }
        public double? AwayPotentialNegativeChance { get; set; }
        public int? AwayMaxPace { get; set; }
        public double? AwayShotOnGoalRate { get; set; }

        public LeagueGameDay GameDay { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public void ApplyHomeTeam(Team team)
        {
            HomeTeamName = team.Name;
            HomeAttackStrength = team.AttackStrength;
            HomeDefenseStrength = team.DefenseStrength;
            HomeGoalKeeperStrength = team.GoalieStrength;
            HomePotentialPositiveShift = team.PotentialPositiveShift;
            HomePotentialPositiveChance = team.PotentialNegativeChance;
            HomePotentialNegativeShift = team.PotentialNegativeShift;
            HomePotentialNegativeChance = team.PotentialNegativeChance;
            HomeMaxPace = team.MaxPace;
            HomeShotOnGoalRate = team.ShotOnGoalRate;
        }

        public void ApplyAwayTeam(Team team)
        {
            AwayTeamName = team.Name;
            AwayAttackStrength = team.AttackStrength;
            AwayDefenseStrength = team.DefenseStrength;
            AwayGoalKeeperStrength = team.GoalieStrength;
            AwayPotentialPositiveShift = team.PotentialPositiveShift;
            AwayPotentialPositiveChance = team.PotentialNegativeChance;
            AwayPotentialNegativeShift = team.PotentialNegativeShift;
            AwayPotentialNegativeChance = team.PotentialNegativeChance;
            AwayMaxPace = team.MaxPace;
            AwayShotOnGoalRate = team.ShotOnGoalRate;
        }

        public void ApplyParameters(League league)
        {
            ShotAccuracyModifier = league.ShotAccuracyModifier;
            PaceModifier = league.PaceModifier;
            MaxHomeAdvantage = league.MaxHomeAdvantage;
            MaxAwayDisadvantage = league.MaxAwayDisadvantage;
        }
    }
}