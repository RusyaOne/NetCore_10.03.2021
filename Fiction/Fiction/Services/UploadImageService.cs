using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fiction.Services
{
    public class UploadImageService : BackgroundService
    {
        private readonly IExternalImageServiceClient _client;
        private readonly IProcessingChannel _channel;

        public UploadImageService(IExternalImageServiceClient client, IProcessingChannel channel)
        {
            _client = client;
            _channel = channel;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    IFormFile image;
                    bool available = _channel.TryRead(out image);

                    if (available)
                    {
                        _client.UploadImage(image);
                    }
                }
                finally
                {
                    await Task.Delay(TimeSpan.FromSeconds(30));
                }
            }
        }
    }
}