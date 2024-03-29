﻿using System.Collections;
using System.Collections.Generic;

namespace Database.Models
{
    public class Continent
    {
        public string Season { get; set; }
        public string Name { get; set; }
        public ICollection<Country> Countries { get; set; }
        public ICollection<Competition> Competitions { get; set; }
    }
}