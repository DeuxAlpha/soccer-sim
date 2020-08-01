using Domain.Enums;

namespace Domain.Models
{
    public class GameStatus
    {
        public int Minute { get; set; }
        public int AddedMinutes { get; set; }
        public int BallPosition { get; set; }
        // If a team has momentum, the attacking strength gets respected. Otherwise, the defending strength gets respected.
        public ActingTeam Momentum { get; set; }
    }
}