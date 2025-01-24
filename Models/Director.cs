using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsScheduleProLibrary.Models
{
    public class Director : Person
    {
        public Club Club { get; set; } //The club that owns the field
        public List<Tournament> Tournaments { get; set; } = new List<Tournament>();
    }
}
