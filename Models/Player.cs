using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary.Models
{
    public class Player : Person
    {
        //Relationships
        public List<Team> Teams { get; set; }
        public List<Coach> Coaches { get; set; }
        public List<AlertContact> AlertContacts { get; set; } = new List<AlertContact>();
    }
}
