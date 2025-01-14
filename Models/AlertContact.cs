using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary
{
    public class AlertContact : Person
    {
        public PreferredContactMethod PreferredContactMethod { get; set; }

        //Relationships
        public List<Player> Players { get; set; }
    }

    public enum PreferredContactMethod
    {
        SMS,
        Phone,
        GroupMe,
        Email
    }
}
