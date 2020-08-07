namespace Database.Models.Shared
{
    public abstract class BaseTournament
    {
        public double ShotAccuracyModifier { get; set; }
        public double PaceModifier { get; set; }
        public double MaxHomeAdvantage { get; set; }
        public double MaxAwayDisadvantage { get; set; }
        public int ActionsPerMinute { get; set; }
        public double MaxProgressChance { get; set; }
        public double MinProgressChance { get; set; }
    }
}