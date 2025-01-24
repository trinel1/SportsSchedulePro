using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary.Models
{
    public class Referee : Person
    {
        public List<Season> Seasons { get; set; }
        public List<League> Leagues { get; set; }
    }
}
