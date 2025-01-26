using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary.Models
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
        public int GameLengthWindow { get; set; }
        public int EarliestGameTimeHourSaturday { get; set; }
        public int EarliestGameTimeMinuteSaturday { get; set; }
        public int EarliestGameTimeHourSunday { get; set; }
        public int EarliestGameTimeMinuteSunday { get; set; }
        public int EarliestGameTimeHourWeekday { get; set; }
        public int EarliestGameTimeMinuteWeekday { get; set; }
        public int PlayEachTimeCount { get; set; } = 1;
        public int DailyGamesPerFieldSaturday { get; set; } = 3;
        public int DailyGamesPerFieldSunday { get; set; } = 1;
        public int DailyGamesPerFieldWeekday { get; set; } = 1;


        //Relationships
        public List<Season> Seasons { get; set; } = new List<Season>();
        public List<Team> Teams { get; set; } = new List<Team>();
        public List<Field> Fields { get; set; } = new List<Field>();
        public List<Referee> Referees { get; set; }
        public Club Club { get; set; }
        public List<Game> Games { get; set; } = new List<Game>();

        public override string ToString()
        {
            return Name;
        }
    }
}
