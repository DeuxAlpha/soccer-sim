namespace Domain.Models
{
    public class GameProperties
    {
        public int HalfFieldLength { get; set; }
        public bool IsExtendedTime { get; set; }
        public int ActionsPerMinute { get; set; }
        public int MaxOvertime { get; set; }
        // How many shots are accurate enough to go on goal.
        public double ShotAccuracyModifier { get; set; }
        // How many shots generally happen.
        public double PaceModifier { get; set; }
        public double MaxHomeAdvantage { get; set; }
        public double MaxAwayDisadvantage { get; set; }
        public double MaxProgressChance { get; set; }
        public double MinProgressChance { get; set; }

        public GameProperties()
        {
            HalfFieldLength = 100;
            ActionsPerMinute = 1;
            MaxOvertime = 8;
            ShotAccuracyModifier = 1;
            IsExtendedTime = false;
            MaxProgressChance = 0.75;
            MinProgressChance = 0.25;
        }
    }
}