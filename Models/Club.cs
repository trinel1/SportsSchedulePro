using SportsScheduleProLibrary.Models;
using System;
using System.Collections.Generic;

namespace SportsScheduleProLibrary.Models
{
    public class Club
    {
        public int ClubId { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public List<Location> Locations { get; set; }
        public List<Season> Seasons { get; set; }
        public List<Field> Fields { get; set; }
        public List<League> Leagues { get; set; }
        public List<Director> Directors { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
