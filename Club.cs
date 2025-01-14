using System;
using System.Collections.Generic;

namespace SportsScheduleProLibrary
{
    public class Club
    {
        public int ClubId { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Season> Seasons { get; set; }
        public List<League> Leagues { get; set; }
    }
}
