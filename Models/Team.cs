using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string ShirtColorChosen { get; set; }
        public string ShortsColorChosen { get; set; }

        //Relationships
        public League League { get; set; }
        public List<Season> Seasons { get; set; } = new List<Season>();
        public List<Player> Players { get; set; } = new List<Player>();
        public List<Coach> Coaches { get; set; } = new List<Coach>();
        public List<Tournament> Tournaments { get; set; } = new List<Tournament>();
        public List<Game> Games { get; set; } = new List<Game>();
        public List<ExcludedGameDate> ExcludedGameDates { get; set; } = new List<ExcludedGameDate>();

        public override string ToString()
        {
            return Name;
        }
    }
}
