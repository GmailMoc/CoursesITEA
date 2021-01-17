using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralHomework.ViewModels
{
    public class AccountRegisterViewModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]*$")]
        public string FisrtName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]*$")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]*$")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords should be equal")]
        public string ConfirmPassword { get; set; }
    }
}
