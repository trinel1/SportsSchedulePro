using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsScheduleProLibrary.Models
{
    public class ExcludedGameDate
    {
        public int ExcludedGameDateId { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime ExcludedDate { get; set; }
        public DateTime? ExcludedTimeStart { get; set; }
        public DateTime? ExcludedTimeEnd { get; set; }

        //Relationships
        public Team Team { get; set; }
    }
}
