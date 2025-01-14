using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary
{
    public class Coach: Person
    {
        public Team Team { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
    }
}
