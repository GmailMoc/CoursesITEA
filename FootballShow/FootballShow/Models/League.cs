using System.ComponentModel.DataAnnotations;

namespace FootballShow.Models
{
    public class League
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string EmblemUrl { get; set; }
    }
}
