using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary.Models
{
    public class Coach: Person
    {
        public List<Team> Teams { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
    }
}
