using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary
{
    public class Location
    {
        public int LocationId { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public bool IsOpenSunday { get; set; }
        public bool IsOpenMonday { get; set; }
        public bool IsOpenTuesday { get; set; }
        public bool IsOpenWednesday { get; set; }
        public bool IsOpenThursday { get; set; }
        public bool IsOpenFriday { get; set; }
        public bool IsOpenSaturday { get; set; }

        //Relationships
        public List<League> Leagues { get; set; } //This is the leagues that are using the fields.
        public Club Club { get; set; } //The club that owns the field
        public List<Field> Fields { get; set; } = new List<Field>();
    }
}
