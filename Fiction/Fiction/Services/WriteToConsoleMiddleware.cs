using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiction.Services
{
    public class WriteToConsoleMiddleware
    {
        private readonly RequestDelegate _next;

        public WriteToConsoleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("This is custom middleware");
            await _next(context);
        }
    }
}