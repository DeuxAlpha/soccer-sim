namespace Domain.Models
{
    public class GameProperties
    {
        public int MaxHalfFieldLength { get; set; }
        public bool IsExtendedTime { get; set; }
        public int ActionsPerMinute { get; set; }
        public int MaxOvertime { get; set; }
        public double ShotAccuracyModifier { get; set; }
        public double PaceModifier { get; set; }
        public double MaxHomeAdvantage { get; set; }
        public double MaxAwayDisadvantage { get; set; }
        public bool ApplyHomeAdvantage { get; set; }

        public GameProperties()
        {
            MaxHalfFieldLength = 100;
            ActionsPerMinute = 1;
            MaxOvertime = 8;
            ShotAccuracyModifier = 1;
            IsExtendedTime = false;
        }
    }
}