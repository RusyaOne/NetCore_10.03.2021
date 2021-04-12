using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Fiction.Services
{
    public class WriteToConsoleMiddleware
    {
        private readonly RequestDelegate _request;
        private readonly string _output;

        public WriteToConsoleMiddleware(RequestDelegate request, string output)
        {
            _request = request;
            _output = output;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine(_output);
            await _request(context);
        }
    }
}