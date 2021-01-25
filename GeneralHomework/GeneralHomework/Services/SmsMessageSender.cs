using System;
using GeneralHomework.Configurations;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace GeneralHomework.Services
{
    public class SmsMessageSender : IMessageSender
    {
        private readonly GeneralAppConfiguration.Sms _configuration;

        public SmsMessageSender(IOptions<GeneralAppConfiguration.Sms> options)
        {
            _configuration = options.Value;
        }

        public void SendMessage(string emailOrPhone, string nameTo = "Andrey", string messageText = "test working")
        {
                TwilioClient.Init(_configuration.TwilioAccountId, _configuration.TwilioAuthToken);

                var message = MessageResource.Create(
                    from: new PhoneNumber(_configuration.TwilioNumber),
                    to: new PhoneNumber(emailOrPhone),
                    body: $"GeneralHomework notification{Environment.NewLine}{messageText}");
        }
    }
}
