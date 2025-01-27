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
