using Fiction.Services;
using Fiction.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Fiction.Controllers
{
    public class ImageController : Controller
    {
        private readonly IExternalImageServiceClient _client;
        private readonly IMemoryCache _cache;
        private readonly IProcessingChannel _channel;

        public ImageController(IExternalImageServiceClient client,
            IMemoryCache cache,
            IProcessingChannel channel)
        {
            _client = client;
            _cache = cache;
            _channel = channel;
        }

        public IActionResult Get()
        {
            var cacheKey = $"image_{DateTime.UtcNow.Date}";
            var image = _cache.Get<byte[]>(cacheKey);

            if (image is null)
            {
                image = _client.GetImage();
                var options = new MemoryCacheEntryOptions();
                options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30);
                _cache.Set<byte[]>(cacheKey, image, options);
            }

            return new FileContentResult(image, "image/jpeg");
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View(new ImageUploadViewModel { UploadStage = UploadStage.Upload });
        }

        [HttpPost]
        public async Task<IActionResult> Upload(ImageUploadViewModel viewModel)
        {
            if (viewModel.Image.Length > 0)
            {
                await _channel.Set(viewModel.Image);
                viewModel.UploadStage = UploadStage.Completed;
                viewModel.Image = null;
            }

            return View(viewModel);
        }
    }
}