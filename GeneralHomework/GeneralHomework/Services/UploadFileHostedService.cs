using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralHomework.Services
{
    public class UploadFileHostedService : BackgroundService
    {
        private IRestApiExampleClient _restClient { get; }
        private FileProcessingChannel _channel { get; }

        public UploadFileHostedService(IRestApiExampleClient restClient, FileProcessingChannel channel)
        {
            _restClient = restClient;
            _channel = channel;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _restClient.UploadFile(_channel.Get());

                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }
    }
}
