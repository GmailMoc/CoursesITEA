using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FootballShow.Models
{
    public class CustomIdentityUser : IdentityUser
    {
        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string FisrtName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string LastName { get; set; }
    }
}
