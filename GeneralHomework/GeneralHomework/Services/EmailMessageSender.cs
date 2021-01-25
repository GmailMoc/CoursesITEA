using GeneralHomework.Configurations;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace GeneralHomework.Services
{
    public class EmailMessageSender : IMessageSender
    {
        private readonly GeneralAppConfiguration.Email _configuration;

        public EmailMessageSender(IOptions<GeneralAppConfiguration.Email> options)
        {
            _configuration = options.Value;
        }

        public void SendMessage(string emailOrPhone, string nameTo = "Andrey", string messageText = "test working")
        {
            //Add header 
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("GeneralHomework", _configuration.EmailAddress));
            message.To.Add(new MailboxAddress(nameTo, emailOrPhone));
            message.Subject = "GeneralHomework notification";

            //Add body
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $"<h1>{messageText}<h1>";
            bodyBuilder.TextBody = messageText;
            message.Body = bodyBuilder.ToMessageBody();

            //Send
            using (SmtpClient client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(_configuration.EmailAddress, _configuration.EmailPassword);

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
