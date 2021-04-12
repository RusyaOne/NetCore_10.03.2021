using RestSharp;
using System;
using System.Collections.Generic;
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
    }
}