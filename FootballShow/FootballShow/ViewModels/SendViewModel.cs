using System.ComponentModel.DataAnnotations;

namespace FootballShow.ViewModels
{
    public class SendViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string MessageText { get; set; }
        [Required]
        public string MailingType { get; set; }
    }
}
