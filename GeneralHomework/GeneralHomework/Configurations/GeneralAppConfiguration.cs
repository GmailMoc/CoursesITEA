using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralHomework.Configurations
{
    public class GeneralAppConfiguration
    {
        public class Email
        {
            public string EmailAddress { get; set; }
            public string EmailPassword { get; set; }
        }
        public class Sms
        {
            public string TwilioAccountId { get; set; }
            public string TwilioAuthToken { get; set; }
            public string TwilioNumber { get; set; }
        }        
    }
}
