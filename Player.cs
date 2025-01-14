using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary
{
    public class Player : Person
    {
        //Relationships
        public Team Team { get; set; }
        public List<Coach> Coaches { get; set; }
        public List<AlertContact> AlertContacts { get; set; } = new List<AlertContact>();
    }
}
