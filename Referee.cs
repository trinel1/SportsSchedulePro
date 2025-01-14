using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary
{
    public class Referee : Person
    {
        public Season Season { get; set; }
        public League League { get; set; }
    }
}
