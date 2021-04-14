using Microsoft.AspNetCore.Http;

namespace Fiction.ViewModels
{
    public class ImageUploadViewModel
    {
        public IFormFile Image { get; set; }
        public UploadStage UploadStage { get; set; }
    }

    public enum UploadStage 
    {
        Upload,
        Completed
    }
}