using SportsScheduleProLibrary.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary.Models
{
    public class Field
    {
        public int FieldId { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public bool IsOpenSunday { get; set; } = true;
        public bool IsOpenMonday { get; set; } = true;
        public bool IsOpenTuesday { get; set; } = true;
        public bool IsOpenWednesday { get; set; } = true;
        public bool IsOpenThursday { get; set; } = true;
        public bool IsOpenFriday { get; set; } = true;
        public bool IsOpenSaturday { get; set; } = true;
        public int EarliestGameTimeHourSaturday { get; set; } = 8;
        public int EarliestGameTimeMinuteSaturday { get; set; } = 0;
        public int EarliestGameTimeHourSunday { get; set; } = 13;
        public int EarliestGameTimeMinuteSunday { get; set; } = 0;
        public int EarliestGameTimeHourWeekday { get; set; } = 17;
        public int EarliestGameTimeMinuteWeekday { get; set; } = 45;
        public int DailyGamesPerFieldSaturday { get; set; } = 3;
        public int DailyGamesPerFieldSunday { get; set; } = 1;
        public int DailyGamesPerFieldWeekday { get; set; } = 1;
        public int FieldGameLengthWindow { get; set; } = 90;


        public bool HasLights { get; set; }
        
        //Relationships
        public List<League> Leagues { get; set; } //This is the leagues that are using the fields.
        public Location Location { get; set; }
        public List<Tournament> Tournaments { get; set; }
        public Club Club { get; set; }
        public List<Game> Games { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
