using System;
using Unity3dAzure.WebSockets;

namespace WebsocketUnity {
    
    public class WebsocketUnityClient : IWebsocketUnityClient {
        
        private IWebSocket _websocketClient;

        public event OnConnectWebsocketClient OnConnect;
        public event OnDisconnectWebsocketClient OnDisconnect;
        public event OnMessageWebsocketClient OnMessage;
        
        public void Open(string url) {
            #if ENABLE_WINMD_SUPPORT
                _websocketClient = new WebSocketUWP();
            #else
                _websocketClient = new WebSocketMono();
            #endif
            _websocketClient.ConfigureWebSocket(url);
            _websocketClient.OnOpen += OnOpenHandler;
            _websocketClient.OnClose += OnCloseHandler;
            _websocketClient.OnMessage += OnMessageHandler;
            _websocketClient.ConnectAsync();
        }
        
        public void Close() {
            _websocketClient?.CloseAsync();
        }
        
        public void Send(string message) {
            _websocketClient?.SendAsync(message);
        }

        private void OnOpenHandler(object sender, EventArgs args) {
            OnConnect?.Invoke();
        }
        
        private void OnCloseHandler(object sender, WebSocketCloseEventArgs e) {
            _websocketClient.OnOpen -= OnOpenHandler;
            _websocketClient.OnClose -= OnCloseHandler;
            _websocketClient.OnMessage -= OnMessageHandler;
            OnDisconnect?.Invoke();
        }

        private void OnMessageHandler(object sender, WebSocketMessageEventArgs e) {
            OnMessage?.Invoke(e.Data);
        }
    }
}