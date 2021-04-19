using System.Net.WebSockets;
using System.Threading.Tasks;

namespace WebSocketsExample.Services
{
    public interface IChatHandler
    {
        Task Handle(WebSocket webSocket);
    }
}