using FootballShow.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FootballShow.Services
{
    public class LoadMatchesHostedService : BackgroundService
    {
        private readonly IServiceProvider _sp;
        //private readonly ILoadMatches _loadMatches;
        private readonly FootballShowConfiguration.LoadMatches _configuration;

        public LoadMatchesHostedService(/*ILoadMatches loadMatches, */IOptions<FootballShowConfiguration.LoadMatches> options, IServiceProvider sp)
        {
            _sp = sp;
            //_loadMatches = loadMatches;
            _configuration = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _sp.CreateScope())
                {
                    var service = scope.ServiceProvider.GetRequiredService<ILoadMatches>();
                    await service.GetMatches(_configuration.Token, _configuration.DefaultUrl);
                }
                //await _loadMatches.GetMatches(_configuration.Token, _configuration.DefaultUrl);

                await Task.Delay(TimeSpan.FromMinutes(_configuration.DelayFromHours));
            }
        }
    }
}
