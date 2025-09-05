using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsScheduleProLibrary.Models
{
    internal class TeamMatch
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public Team Home { get; set; }
        public Team Away { get; set; }
    }
}
