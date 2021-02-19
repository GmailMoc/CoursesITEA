using System;
using System.ComponentModel.DataAnnotations;

namespace FootballShow.Models
{
    public class Match
    {
        [Required]
        public int Id { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime LocalDate { get; set; }

        public string TeamWinner { get; set; }


        [Required]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
