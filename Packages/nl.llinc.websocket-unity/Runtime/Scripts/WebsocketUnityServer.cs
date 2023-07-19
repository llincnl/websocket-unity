using System.Collections.Generic;
using System.Net;
using WebSocketSharp.Server;

namespace WebsocketUnity {
    
    public class WebsocketUnityServer : IWebsocketUnityServer {

        private WebSocketServer _webSocketServer;

        public event OnConnectWebsocketServer OnConnect;
        public event OnDisconnectWebsocketServer OnDisconnect;
        public event OnMessageWebsocketServer OnMessage;
        public string url { get; }
        public string address { get; }
        public int port { get; }

        private Dictionary<string, string> _endpoints = new Dictionary<string, string>();
        private Dictionary<string, WebsocketUnitySession> _sessions = new Dictionary<string, WebsocketUnitySession>();
        
        public WebsocketUnityServer(string address, int port = 3080) {
            this.address = address;
            this.port = port;
            url = "ws://" + address + ":" + port;
        }
        
        public void Open() {
            _webSocketServer = new WebSocketServer(url);
            _webSocketServer.AddWebSocketService<WebsocketUnitySession>("/", session => {
                session.OnOpenSession += OnOpenSessionHandler;
                session.OnCloseSession += OnCloseSessionHandler;
                session.OnMessageSession += OnMessageSessionHandler;
            });
            _webSocketServer.Start();
        }
        
        public void Close() {
            _webSocketServer?.Stop();
        }
        
        public void SendOne(IPEndPoint clientEndPoint, string message) {
            if (_endpoints.ContainsKey(clientEndPoint.ToString())) {
                _webSocketServer.WebSocketServices["/"].Sessions.SendTo(message, _endpoints[clientEndPoint.ToString()]);
            }
        }
        
        public void SendMany(IPEndPoint[] clientEndPoints, string message) {
            foreach (var endpoint in clientEndPoints) {
                if (_endpoints.ContainsKey(endpoint.ToString())) {
                    _webSocketServer.WebSocketServices["/"].Sessions.SendTo(message, _endpoints[endpoint.ToString()]);
                }
            }
        }
        
        public void SendAll(string message) {
            _webSocketServer.WebSocketServices["/"].Sessions.Broadcast(message);
        }

        public void OnOpenSessionHandler(WebsocketUnitySession session) {
            _endpoints.Add(session.Context.UserEndPoint.ToString(), session.ID);
            OnConnect?.Invoke(session.Context.UserEndPoint);
        }
        
        public void OnCloseSessionHandler(WebsocketUnitySession session) {
            session.OnOpenSession -= OnOpenSessionHandler;
            session.OnCloseSession -= OnCloseSessionHandler;
            session.OnMessageSession -= OnMessageSessionHandler;
            OnDisconnect?.Invoke(session.Context.UserEndPoint);
        }

        public void OnMessageSessionHandler(WebsocketUnitySession session, string data) {
            OnMessage?.Invoke(session.Context.UserEndPoint, data);
        }
    }
}