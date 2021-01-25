using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralHomework.ViewModels
{
    public class HomeSendViewModel
    {
        [Required]
        public string EmailOrPhone { get; set; }
        [Required]
        public string MessageText { get; set; }
        [Required]
        public string MailingType { get; set; }
    }
}
