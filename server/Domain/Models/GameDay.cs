using System.Collections;
using System.Collections.Generic;

namespace Domain.Models
{
    public class GameDay<T>
    {
        public List<MatchUp<T>> Games { get; set; }

        public GameDay()
        {
            Games = new List<MatchUp<T>>();
        }
    }
}