using Microsoft.AspNetCore.Mvc;

namespace ExternalImageService.Controllers
{
    [ApiController]
    public class ImageController : Controller
    {
        [HttpGet("Image")]
        public IActionResult GetImage()
        {
            var imageBytes = System.IO.File.ReadAllBytes("wwwroot/TerrainImage55.jpg");
            return new FileContentResult(imageBytes, "image/jpeg");
        }
    }
}