using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballShow.ViewModels
{
    public class MatchIndexViewModel
    {
        public int Id { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime LocalDate { get; set; }

        public int TeamId { get; set; }

        public string TeamName { get; set; }
    }
}
