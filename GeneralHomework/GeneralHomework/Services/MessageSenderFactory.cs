using GeneralHomework.Configurations;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralHomework.Services
{
    public class MessageSenderFactory : IMessageSenderFactory
    {
        private readonly IOptions<GeneralAppConfiguration.Email> _emailConfig;
        private readonly IOptions<GeneralAppConfiguration.Sms> _smsConfig;

        public MessageSenderFactory(IOptions<GeneralAppConfiguration.Email> emailoptions, IOptions<GeneralAppConfiguration.Sms> smsOptions)
        {
            _emailConfig = emailoptions;
            _smsConfig = smsOptions;
        }

        public IMessageSender MailingType(string senderType)
        {
            if (senderType.ToLower() == "sms")
                return new SmsMessageSender(_smsConfig);
            else if (senderType.ToLower() == "email")
                return new EmailMessageSender(_emailConfig);
            else
                return null;
        }
    }
}
