function SendHandshake() {
    function GetWebSocketMessages(onMessageReceived) {
        var url = `wss://${location.host}/stream/get`
        console.log('url is: ' + url);

        var webSocket = new WebSocket(url);

        webSocket.onmessage = onMessageReceived;
    };

    var ulElement = document.getElementById('StreamToMe');

    GetWebSocketMessages(function (message) {
        console.log(message.data)
        ulElement.innerHTML = ulElement.innerHTML += `<li>Привет, друг!</li>`
    });
};

SendHandshake();