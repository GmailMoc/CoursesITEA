using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GeneralHomework.Services
{
    public class UploadFileHostedService : BackgroundService
    {
        //private IRestApiExampleClient _restClient { get; }
        private readonly IServiceProvider _sp;
        private FileProcessingChannel _channel { get; }

        public UploadFileHostedService(/*IRestApiExampleClient restClient, */FileProcessingChannel channel, IServiceProvider sp)
        {
            //_restClient = restClient;
            _sp = sp;
            _channel = channel;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                /*IFormFile image = await _channel.GetAsync();
                if (image != null)
                {
                    _restClient.UploadFile(image);
                }*/
                await foreach (IFormFile image in _channel.GetAllAsync())
                {
                    if (image != null)
                    {
                        using (var scope = _sp.CreateScope())
                        {
                            var service = scope.ServiceProvider.GetRequiredService<IRestApiExampleClient>();
                            service.UploadFile(image);
                        }
                    }
                }
            
                await Task.Delay(TimeSpan.FromSeconds(40));
            }
        }
    }
}
