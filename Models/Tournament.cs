﻿using SportsScheduleProLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //Relationships
        public Location Location { get; set; }
        public List<Team> Teams { get; set; } = new List<Team>();
        public List<Field> Fields { get; set; } = new List<Field>();
        public Director Director { get; set; }
    }
}
