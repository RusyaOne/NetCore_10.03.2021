using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fiction.Services
{
    public class LoadImageService : BackgroundService
    {
        private readonly IExternalImageServiceClient _client;
        private readonly IMemoryCache _cache;

        public LoadImageService(IExternalImageServiceClient client, IMemoryCache cache)
        {
            _client = client;
            _cache = cache;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var cacheKey = $"image_{DateTime.UtcNow.Date}";
                var callInterval = TimeSpan.FromMinutes(2);

                var image = _client.GetImage();
                var options = new MemoryCacheEntryOptions();
                options.AbsoluteExpirationRelativeToNow = callInterval;
                _cache.Set<byte[]>(cacheKey, image, options);

                await Task.Delay(callInterval);
            }
        }
    }
}