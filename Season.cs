using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary
{
    public class Season
    {
        public int SeasonId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<DayOfWeek> AvailableDaysOfWeek { get; set; } = new List<DayOfWeek> { DayOfWeek.Friday, DayOfWeek.Monday, DayOfWeek.Saturday, DayOfWeek.Thursday, DayOfWeek.Tuesday, DayOfWeek.Wednesday };


        //Relationships
        public Club Club { get; set; }
        public List<League> Leagues { get; set; }

    }
}
