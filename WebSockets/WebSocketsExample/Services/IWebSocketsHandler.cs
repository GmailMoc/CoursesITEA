using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace WebSocketsExample.Services
{
    public interface IWebSocketsHandler
    {
        public Task HandleAsync(string username, WebSocket webSocket);
    }
}
