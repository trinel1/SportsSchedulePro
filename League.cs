using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary
{
    public class League
    {
        public int LeagueId { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string AgeGroup { get; set; }
        public DateTime? AgeGroupEarliestDate { get; set; }
        public DateTime? AgeGroupLatestDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //Relationships
        public Club Club { get; set; }
        public List<Season> Seasons { get; set; } = new List<Season>();
        public List<Team> Teams { get; set; } = new List<Team>();
        public List<Field> Fields { get; set; } = new List<Field>();
    }
}
