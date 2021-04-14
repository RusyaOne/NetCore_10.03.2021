using Microsoft.AspNetCore.Http;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Services
{
    public class ExternalImageServiceClient : IExternalImageServiceClient
    {
        public byte[] GetImage()
        {
            var client = new RestClient("http://localhost:56227");
            var request = new RestRequest("Image", Method.GET);

            var result = client.Execute(request).RawBytes;
            return result;
        }

        public void UploadImage(IFormFile image)
        {
            var client = new RestClient("http://localhost:56227");
            var request = new RestRequest("Image", Method.POST);

            using (var stream = new MemoryStream())
            {
                image.CopyTo(stream);
                request.AddJsonBody(Convert.ToBase64String(stream.ToArray()));
                request.AddQueryParameter("imageName", image.FileName);
                client.Execute(request);
            }
        }
    }
}