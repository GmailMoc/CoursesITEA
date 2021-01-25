using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralHomework.Services
{
    public interface IMessageSender
    {
        void SendMessage(string emailOrPhone, string nameTo = "Andrey", string messageText = "test working");
    }
}
