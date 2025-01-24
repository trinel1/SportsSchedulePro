using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary.Models
{
    public class AlertContact : Person
    {
        public PreferredContactMethod PreferredContactMethod { get; set; }

        //Relationships
        public List<Player> Players { get; set; }
        public List<Alert> Alerts { get; set; }
    }

    public enum PreferredContactMethod
    {
        SMS,
        Phone,
        GroupMe,
        Email
    }
}
