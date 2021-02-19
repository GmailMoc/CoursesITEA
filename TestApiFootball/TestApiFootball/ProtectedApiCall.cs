//using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestApiFootball
{
    public class ProtectedApiCall
    {
        protected HttpClient HttpClient { get; private set; }

        public ProtectedApiCall(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task CallWebApiAsunc(string webApiUrl, string accessToken)
        {
            try
            {
                if (!string.IsNullOrEmpty(accessToken))
                {
                    var defaultRequestHeaders = HttpClient.DefaultRequestHeaders;
                    if (defaultRequestHeaders.Accept == null || !defaultRequestHeaders.Accept.Any(m => m.MediaType == "application/json"))
                    {
                        HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpClient.Timeout = TimeSpan.FromMinutes(2);
                    }
                    //defaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-auth-token", accessToken);
                    defaultRequestHeaders.Add("x-auth-token", accessToken);

                    HttpResponseMessage response = await HttpClient.GetAsync(webApiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Success: {response.StatusCode}");
                        //Leagues leagues = JsonSerializer.Deserialize<Leagues>(json);

                        /*foreach (League league in leagues.competitions)
                        {

                        }*/

                        Games games = JsonSerializer.Deserialize<Games>(json);

                        foreach (var match in games.matches)
                        {
                            Console.WriteLine($@"Date match: {match.utcDate.ToLocalTime()}");
                            Console.WriteLine($@"{match.homeTeam.name} {match.score.fullTime.homeTeam} - {match.score.fullTime.awayTeam} {match.awayTeam.name}");
                            string winner = ""; 
                            if(match.score.winner == "HOME_TEAM")
                            {
                                winner = match.homeTeam.name;
                            }
                            else if (match.score.winner == "AWAY_TEAM")
                            {
                                winner = match.awayTeam.name;
                            }
                            else
                            {
                                winner = match.score.winner;
                            }
                            Console.WriteLine($@"Winner: {winner}");
                            Console.WriteLine();
                        }

                        //LeagueModel leagueModel = JsonConvert.DeserializeObject<LeagueModel>(json);
                        Console.WriteLine(json);
                    }
                    else
                    {
                        string jsonErr = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Error: {response.StatusCode}");
                        Console.WriteLine(jsonErr);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
