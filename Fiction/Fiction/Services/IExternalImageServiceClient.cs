using Microsoft.AspNetCore.Http;

namespace Fiction.Services
{
    public interface IExternalImageServiceClient
    {
        byte[] GetImage();
        void UploadImage(IFormFile image);
    }
}