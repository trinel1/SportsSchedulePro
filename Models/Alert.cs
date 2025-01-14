using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary
{
    public class Alert
    {
        public int AlertId { get; set; }
        public bool IsDeleted { get; set; }

        //Relationships
        public List<League> Leagues { get; set; } //This is the leagues that are using the fields.
        public List<AlertContact> AlertContacts { get; set; } = new List<AlertContact>();
        public Club Club { get; set; } //The club that owns the field
    }
}
