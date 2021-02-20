using FootballShow.Models.Repositories;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FootballShow.Services
{
    public class LoadMatches : ILoadMatches
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMatchRepository _matchRepository;
        private HttpClient httpClient;
        private ProtectedApiCall apiCall;

        public LoadMatches(ITeamRepository teamRepository, IMatchRepository matchRepository)
        {
            _teamRepository = teamRepository;
            _matchRepository = matchRepository;
            httpClient = new HttpClient();
            apiCall = new ProtectedApiCall(httpClient, _matchRepository);
        }

        public async Task GetMatches(string accessToken, string defaultUrl)
        {
            foreach (var team in _teamRepository.GetAllTeams())
            {
                await apiCall.CallWebApiAsunc(defaultUrl + team.Id + 
                    "/matches?dateFrom=" + DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd") + 
                    "&dateTo=" + DateTime.Today.ToString("yyyy-MM-dd"), 
                    accessToken,
                    team.Id);
            }
        }
    }
}
