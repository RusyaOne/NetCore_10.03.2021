using Microsoft.AspNetCore.Http;
using RestSharp;
using System;
using System.IO;

namespace Fiction.Services
{
    public class ExternalImageServiceClient : IExternalImageServiceClient
    {
        private const string ImageClientUrl = "http://localhost:56227";

        private readonly IRestClient _restClient;

        public ExternalImageServiceClient(IRestClient restClient)
        {
            _restClient = restClient;
            _restClient.BaseUrl = new Uri(ImageClientUrl);
        }

        public byte[] GetImage()
        {
            var request = new RestRequest("Image", Method.GET);

            var result = _restClient.Execute(request).RawBytes;
            return result;
        }

        public void UploadImage(IFormFile image)
        {
            var request = new RestRequest("Image", Method.POST);

            using var stream = new MemoryStream();
            
            image.CopyTo(stream);
            request.AddJsonBody(Convert.ToBase64String(stream.ToArray()));
            request.AddQueryParameter("imageName", image.FileName);
            _restClient.Execute(request);            
        }
    }
}