using FootballShow.Models;
using FootballShow.Models.Repositories;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace FootballShow.Services
{
    public class ProtectedApiCall
    {
        private readonly IMatchRepository _matchRepository;
        protected HttpClient HttpClient { get; private set; }

        public ProtectedApiCall(HttpClient httpClient, IMatchRepository matchRepository)
        {
            HttpClient = httpClient;
            _matchRepository = matchRepository;
        }

        public async Task CallWebApiAsunc(string webApiUrl, string accessToken, int teamId)
        {
            try
            {
                if (!string.IsNullOrEmpty(accessToken))
                {
                    HttpRequestHeaders defaultRequestHeaders = HttpClient.DefaultRequestHeaders;
                    if (defaultRequestHeaders.Accept == null || !defaultRequestHeaders.Accept.Any(m => m.MediaType == "application/json"))
                    {
                        HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        defaultRequestHeaders.Add("x-auth-token", accessToken);
                        HttpClient.Timeout = TimeSpan.FromMinutes(15);
                    }

                    HttpResponseMessage response = await HttpClient.GetAsync(webApiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        //удаляю записи из БД в которых TeamId равен обновляемому TeamId
                        foreach (var match in _matchRepository.GetAllMatches().Where(m => m.TeamId == teamId))
                        {
                            _matchRepository.RemoveMatch(match.Id);
                        }

                        string json = await response.Content.ReadAsStringAsync();

                        Games games = JsonSerializer.Deserialize<Games>(json);

                        foreach (var game in games.matches)
                        {
                            string winner = "";

                            if (game.score.winner == "HOME_TEAM")
                                winner = game.homeTeam.name;
                            else if (game.score.winner == "AWAY_TEAM")
                                winner = game.awayTeam.name;
                            else
                                winner = game.score.winner;

                            _matchRepository.AddMatch(new Match
                            {
                                HomeTeam = game.homeTeam.name,
                                AwayTeam = game.awayTeam.name,
                                HomeTeamGoals = game.score.fullTime.homeTeam ?? default(int),
                                AwayTeamGoals = game.score.fullTime.awayTeam ?? default(int),
                                LocalDate = game.utcDate.ToLocalTime(),
                                TeamWinner = winner,
                                TeamId = teamId
                            });
                        }
                    }
                    else
                    {
                        //здесь можно было бы еще выкидывать Exception, но я не стал заморачиваться... 
                        string jsonErr = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Error: {response.StatusCode}");
                        Console.WriteLine(jsonErr);
                    }
                }
            }
            catch (Exception ex)
            {
                throw; //Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
