using Domain.Enums;

namespace Domain.Models
{
    public class GameStatus
    {
        public int Minute { get; set; }
        public int AddedMinutes { get; set; }
        public int BallPosition { get; set; }
    }
}