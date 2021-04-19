﻿function SendHandshake() {
    function GetWebSocketMessages(onMessageReceived) {
        var url = `wss://${location.host}/stream/handshake`
        console.log('url is: ' + url);

        var webSocket = new WebSocket(url);

        webSocket.onmessage = onMessageReceived;
    };

    var ulElement = document.getElementById('StreamToMe');

    GetWebSocketMessages(function (message) {
        ulElement.innerHTML = ulElement.innerHTML + `<li>${message.data}</li>`
    });
};

SendHandshake();