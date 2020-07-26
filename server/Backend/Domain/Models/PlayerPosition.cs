using Domain.Enums;

namespace Domain.Models
{
    public class PlayerPosition
    {
        public Player Player { get; set; }
        public Position Position { get; set; }
    }
}