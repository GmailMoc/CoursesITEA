using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketsExample.Services;

namespace WebSocketsExample.Controllers
{
    /*
     Заметил, что данные в браузере кешируются, и в случае неправильной работы "чата" даже после перезапуска ничего не работает... 
     Например, если запустить проект два раза без отладки (Ctrl + F5), но не переходить по url = ...stream/chat, а потом 
     на двух вкладках браузера перейти по ссылке на чат, то пишу юзернейм, нажимаю присоедениться - и ничего... 
     и потом даже если перезапускаю браузер, то всё равно не работает... в чате ничего не происходит при нажатии "Join Chat"
     помогает исправить ситуация пересборка проекта или очистка кэша браузера
     */
    public class StreamController : Controller
    {
        private IWebSocketsHandler _handler;

        public StreamController(IWebSocketsHandler handler)
        {
            _handler = handler;
        }

        /*
         не совсем понял в чем смысл работы "stream.js", так как ничего не происходит на экране...
         Возможно я что-то не так написал?
         */
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Chat()
        {
            return View();
        }

        public async Task Get(string username)
        {
            HttpContext context = ControllerContext.HttpContext;
            bool isWebSocketRequest = context.WebSockets.IsWebSocketRequest;

            if (isWebSocketRequest)
            {
                WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                await _handler.HandleAsync(username, webSocket);
                //await _handler.HandleAsync(Guid.NewGuid(), webSocket);
            }
            else
            {
                context.Response.StatusCode = 400;
            }
        }

        private async Task SendMessage(WebSocket webSocket)
        {
            for (int i = 0; ; i++)
            {
                var bytes = Encoding.ASCII.GetBytes("Message" + i);
                await webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
                Thread.Sleep(1000);
            }
        }
    }
}
