using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Threading.Tasks;
using WebSocketsExample.Services;

namespace WebSocketsExample.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChatHandler _chatHandler;

        public ChatController(IChatHandler chatHandler)
        {
            _chatHandler = chatHandler;
        }

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
                await _chatHandler.Handle(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }
    }
}