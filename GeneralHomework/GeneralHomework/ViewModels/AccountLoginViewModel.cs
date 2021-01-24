using System.ComponentModel.DataAnnotations;

namespace GeneralHomework.ViewModels
{
    public class AccountLoginViewModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]*$")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
