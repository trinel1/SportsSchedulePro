using System;
using System.Collections.Generic;
using System.Text;

namespace SportsScheduleProLibrary
{
    public class Alert
    {
        public int AlertId { get; set; }
        public bool IsDeleted { get; set; }
        public string Message { get; set; }
        public string AlertType { get; set; }
        public DateTime? AlertDate { get; set; }
        public DateTime? EndDate { get; set; }

        //Relationships
        public List<League> Leagues { get; set; } //This is the leagues that are using the fields.
        public List<AlertContact> AlertContacts { get; set; } = new List<AlertContact>();
        public Club Club { get; set; } //The club that owns the field
    }

    public class AlertType
    {
        public readonly static string Weather = "Weather";
        public readonly static string Closures = "Closures";
        public readonly static string SeasonStart = "SeasonStart";
        public readonly static string SeasonEnd = "SeasonEnd";
        public readonly static string TournamentStart = "TournamentStart";
        public readonly static string Other = "Other";
    }
}
