using System.Collections.Generic;

namespace Domain.Models
{
    public class TeamLineUp
    {
        public List<PlayerPosition> Formation { get; set; }
        public double Strength { get; set; }
    }
}