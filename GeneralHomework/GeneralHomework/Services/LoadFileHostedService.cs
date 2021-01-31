using GeneralHomework.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralHomework.Services
{
    public class LoadFileHostedService : BackgroundService
    {
        //private readonly IRestApiExampleClient _restClient;
        private readonly IServiceProvider _sp;
        private readonly ILoadFile _loadFile;
        private readonly GeneralAppConfiguration.LoadFile _configuration;

        public LoadFileHostedService(/*IRestApiExampleClient restClient, */ILoadFile loadFile, IOptions<GeneralAppConfiguration.LoadFile> options, IServiceProvider sp)
        {
            //_restClient = restClient;
            _sp = sp;
            _loadFile = loadFile;
            _configuration = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            string imageName = "TerrainImage15.jpg";
            while (!cancellationToken.IsCancellationRequested)
            {
                byte[] image = _loadFile.GetImage(imageName);

                if (image == null)
                {
                    using (var scope = _sp.CreateScope())
                    {
                        var service = scope.ServiceProvider.GetRequiredService<IRestApiExampleClient>();
                        image = service.GetFile(imageName);
                    }
                    _loadFile.CacheSet(image, imageName);
                }

                await Task.Delay(TimeSpan.FromMinutes(_configuration.DelayFromMinutes));
            }
        }
    }
}
