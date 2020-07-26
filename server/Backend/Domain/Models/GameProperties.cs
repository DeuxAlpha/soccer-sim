namespace Domain.Models
{
    public class GameProperties
    {
        public int MaxHalfFieldLength { get; set; }
        public bool IsExtendedTime { get; set; }
        public int ActionsPerMinute { get; set; }
        public int MaxOvertime { get; set; }

        public GameProperties()
        {
            MaxHalfFieldLength = 100;
            ActionsPerMinute = 1;
            MaxOvertime = 8;
            IsExtendedTime = false;
        }
    }
}