using GeneralHomework.Configurations;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralHomework.Services
{
    public interface IMessageSenderFactory
    {
        public IMessageSender MailingType(string senderType);
    }
}
