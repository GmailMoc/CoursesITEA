using System.ComponentModel.DataAnnotations;

namespace FootballShow.Models
{
    public class Team
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string WebSite { get; set; }

        [Required]
        public string Arena { get; set; }


        [Required]
        public int LeagueId { get; set; }
        public virtual League League { get; set; }
    }
}
