using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary.Models
{
    public class Season
    {
        public int SeasonId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsOpenSunday { get; set; }
        public bool IsOpenMonday { get; set; }
        public bool IsOpenTuesday { get; set; }
        public bool IsOpenWednesday { get; set; }
        public bool IsOpenThursday { get; set; }
        public bool IsOpenFriday { get; set; }
        public bool IsOpenSaturday { get; set; }

        //Relationships
        public Club Club { get; set; }
        public List<League> Leagues { get; set; }
        public List<Referee> Referees { get; set; }
        public List<Team> Teams { get; set; }

        public override string ToString()
        {
            return StartDate?.ToShortDateString() + " - " + EndDate?.ToShortDateString();
        }

    }
}
