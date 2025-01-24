using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public bool IsDeleted { get; set; }

        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }

    }
}
