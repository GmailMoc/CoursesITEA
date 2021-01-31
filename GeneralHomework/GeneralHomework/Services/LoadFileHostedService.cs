using GeneralHomework.Configurations;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralHomework.Services
{
    public class LoadFileHostedService : BackgroundService
    {
        private readonly IRestApiExampleClient _restClient;
        private readonly ILoadFile _loadFile;
        private readonly GeneralAppConfiguration.LoadFile _configuration;

        public LoadFileHostedService(IRestApiExampleClient restClient, ILoadFile loadFile, IOptions<GeneralAppConfiguration.LoadFile> options)
        {
            _restClient = restClient;
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
                    image = _restClient.GetFile(imageName);
                    _loadFile.CacheSet(image, imageName);
                }

                await Task.Delay(TimeSpan.FromMinutes(_configuration.DelayFromMinutes));
            }
        }
    }
}
