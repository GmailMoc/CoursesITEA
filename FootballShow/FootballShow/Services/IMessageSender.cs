
namespace FootballShow.Services
{
    public interface IMessageSender
    {
        void SendMessage(string email, string nameTo = "Andrey", string messageText = "test working");
    }
}
