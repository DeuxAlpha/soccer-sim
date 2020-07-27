using System.Collections;
using System.Collections.Generic;

namespace Domain.Models
{
    public class GameDay
    {
        public List<MatchUp> Games { get; set; }

        public GameDay()
        {
            Games = new List<MatchUp>();
        }
    }
}