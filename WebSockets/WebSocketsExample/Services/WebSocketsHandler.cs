using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketsExample.Services
{
    public class WebSocketHandler : IWebSocketsHandler
    {
        //private ConcurrentDictionary<Guid, WebSocket> websocketConnections = new ConcurrentDictionary<Guid, WebSocket>();
        private ConcurrentDictionary<string, WebSocket> websocketConnections = new ConcurrentDictionary<string, WebSocket>();

        public async Task HandleAsync(string username, WebSocket webSocket)
        {
            bool addedSucessfully = websocketConnections.TryAdd(username, webSocket);

            if (addedSucessfully)
            {
                await SendToAllSockets($"User {username} joined the chat.");

                while (webSocket.State == WebSocketState.Open)
                {
                    string message = await Receive(webSocket, username);
                    if (message != null)
                        await SendToAllSockets(message);
                }
            }
        }

        private async Task SendToAllSockets(string message)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            foreach (var pair in websocketConnections)
            {
                await pair.Value.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        private async Task<string> Receive(WebSocket webSocket, string username)
        {
            ArraySegment<byte> arraySegment = new ArraySegment<byte>(new byte[1024]);
            WebSocketReceiveResult receivedResult = await webSocket.ReceiveAsync(arraySegment, CancellationToken.None);
            if (receivedResult.MessageType == WebSocketMessageType.Text)
            {
                string message = Encoding.UTF8.GetString(arraySegment).TrimEnd();
                if (!string.IsNullOrWhiteSpace(message))
                    return $"{username}: {message}";
            }
            return null;
        }
    }
}
