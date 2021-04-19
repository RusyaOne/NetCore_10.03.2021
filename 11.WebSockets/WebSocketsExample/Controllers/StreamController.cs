using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketsExample.Controllers
{
    public class StreamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task Handshake()
        {
            var webSockets = HttpContext.WebSockets;

            if (webSockets.IsWebSocketRequest)
            {
                WebSocket webSocket = await webSockets.AcceptWebSocketAsync();
                await SendMessages(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        private static async Task SendMessages(WebSocket webSocket)
        {
            while (true)
            {
                var messageBytes = Encoding.UTF8.GetBytes("Request from server message");
                await webSocket.SendAsync(messageBytes, WebSocketMessageType.Text, true, CancellationToken.None);
                await Task.Delay(TimeSpan.FromSeconds(2));
            }
        }
    }
}