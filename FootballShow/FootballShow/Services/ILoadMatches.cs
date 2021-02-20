using System.Threading.Tasks;

namespace FootballShow.Services
{
    public interface ILoadMatches
    {
        Task GetMatches(string accessToken, string defaultUrl);
    }
}
