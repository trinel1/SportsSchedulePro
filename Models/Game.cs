using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsScheduleProLibrary.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public bool IsDeleted { get; set; }


        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public Field Field { get; set; }
        public DateTime ChosenScheduleTime { get; set; }
        public League League { get; set; }
    }
}
