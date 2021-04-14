using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace ExternalImageService.Controllers
{
    [ApiController]
    public class ImageController : Controller
    {
        [HttpGet("Image")]
        public IActionResult Get()
        {
            var imageBytes = System.IO.File.ReadAllBytes("wwwroot/TerrainImage55.jpg");
            return new FileContentResult(imageBytes, "image/jpeg");
        }

        [HttpPost("Image")]
        public void Upload([FromBody]string image, [FromQuery]string imageName)
        {
            var imagePath = Path.Combine("wwwroot", imageName);
            var imageBytes = Convert.FromBase64String(image);
            System.IO.File.WriteAllBytes(imagePath, imageBytes);
        }
    }
}