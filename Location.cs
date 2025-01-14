using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary
{
    public class Location
    {
        public int FieldId { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public List<DayOfWeek> AvailableDaysOfWeek { get; set; } = new List<DayOfWeek> { DayOfWeek.Friday, DayOfWeek.Monday, DayOfWeek.Saturday, DayOfWeek.Thursday, DayOfWeek.Tuesday, DayOfWeek.Wednesday };

        //Relationships
        public List<League> Leagues { get; set; } //This is the leagues that are using the fields.
        public Club Club { get; set; } //The club that owns the field
        public List<Field> Fields { get; set; } = new List<Field>();
    }
}
