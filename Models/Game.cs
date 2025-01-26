using SportsScheduleProLibrary.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsScheduleProLibrary.Models
{
    public class Game
    {
        public static SportsScheduleProDataContext dbc = new SportsScheduleProDataContext();

        public int GameId { get; set; }
        public bool IsDeleted { get; set; }


        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public Field Field { get; set; }
        public DateTime ChosenScheduleTime { get; set; }
        public League League { get; set; }

        public override string ToString()
        {
            return string.Format("{0} vs. {1}, {2}", dbc.Teams.Where(s => s.TeamId == AwayTeamId).Select(s => s.Name).FirstOrDefault(), dbc.Teams.Where(s => s.TeamId == HomeTeamId).Select(s => s.Name).FirstOrDefault(), ChosenScheduleTime);
        }
    }
}
