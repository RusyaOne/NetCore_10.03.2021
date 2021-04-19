using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketsExample.Services
{
    public class ChatHandler : IChatHandler
    {
        private ConcurrentDictionary<Guid, WebSocket> webSocketConnections;

        public ChatHandler()
        {
            webSocketConnections = new ConcurrentDictionary<Guid, WebSocket>();
        }

        public async Task Handle(WebSocket webSocket)
        {
            var userGuid = Guid.NewGuid();
            webSocketConnections.TryAdd(Guid.NewGuid(), webSocket);

            await Send($"User {userGuid} entered the chat");

            while (webSocket.State == WebSocketState.Open)
            {
                var message = await Receive(webSocket);

                if (!string.IsNullOrWhiteSpace(message))
                {
                    await Send(message);
                }
            }
        }

        private static async Task<string> Receive(WebSocket webSocket)
        {
            var messageBuffer = new ArraySegment<byte>(new byte[1024]);
            var receiveResult = await webSocket.ReceiveAsync(messageBuffer, CancellationToken.None);

            if (receiveResult.MessageType == WebSocketMessageType.Text)
            {
                return Encoding.UTF8.GetString(messageBuffer).Trim('\0');           
            }

            return null;
        }

        private async Task Send(string message)
        {
            foreach (var connection in webSocketConnections.Values)
            {
                var messageBytes = Encoding.UTF8.GetBytes(message);
                await connection.SendAsync(messageBytes, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}