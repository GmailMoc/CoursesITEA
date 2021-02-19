using System;
using System.Net.Http;

namespace TestApiFootball
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            ProtectedApiCall apiCall = new ProtectedApiCall(httpClient);

            //ЛИГИ
            //await apiCall.CallWebApiAsunc("http://api.football-data.org/v2/competitions?plan=TIER_ONE", "5505856a5a574e97a75877082d134456");

            //МАТЧИ
            await apiCall.CallWebApiAsunc("http://api.football-data.org/v2/teams/1/matches?dateFrom=" + DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd") + "&dateTo=" + DateTime.Today.ToString("yyyy-MM-dd"), "5505856a5a574e97a75877082d134456");
        }
    }
}
