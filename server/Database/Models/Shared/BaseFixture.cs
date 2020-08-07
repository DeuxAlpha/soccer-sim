namespace Database.Models.Shared
{
    public abstract class BaseFixture
    {
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public int HalfFieldLength { get; set; }
        public int ActionsPerMinute { get; set; }
        public int MaxOvertime { get; set; }
        public double ShotAccuracyModifier { get; set; }
        public double PaceModifier { get; set; }
        public double MaxHomeAdvantage { get; set; }
        public double MaxAwayDisadvantage { get; set; }

        public int? HomePossession { get; set; }
        public int? AwayPossession { get; set; }
    }
}