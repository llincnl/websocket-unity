using System.Net;

namespace WebsocketUnity {
    
    /// <summary>
    /// Delegate for a WebSocket server connect event.
    /// </summary>
    /// <param name="clientId">The ID of the client that connected.</param>
    public delegate void OnConnectWebsocketServer(IPEndPoint clientId);
    
    /// <summary>
    /// Delegate for a WebSocket server disconnect event.
    /// </summary>
    /// <param name="clientId">The ID of the client that disconnected.</param>
    public delegate void OnDisconnectWebsocketServer(IPEndPoint clientId);
    
    /// <summary>
    /// Delegate for a WebSocket server message event.
    /// </summary>
    /// <param name="clientId">The ID of the client that sent the message.</param>
    /// <param name="message">The message received from the client.</param>
    public delegate void OnMessageWebsocketServer(IPEndPoint clientId, string message);
    
    /// <summary>
    /// Interface for a WebSocket server.
    /// </summary>
    public interface IWebsocketUnityServer {

        /// <summary>
        /// Event triggered when a client connects to the WebSocket server.
        /// </summary>
        public event OnConnectWebsocketServer OnConnect;
        
        /// <summary>
        /// Event triggered when a client disconnects from the WebSocket server.
        /// </summary>
        public event OnDisconnectWebsocketServer OnDisconnect;
        
        /// <summary>
        /// Event triggered when the WebSocket server receives a message from a client.
        /// </summary>
        public event OnMessageWebsocketServer OnMessage;
        
        /// <summary>
        /// The URL of the WebSocket server.
        /// </summary>
        public string url { get; }
        
        /// <summary>
        /// The IP address of the WebSocket server.
        /// </summary>
        public string address { get; }
        
        /// <summary>
        /// The port that the WebSocket server is listening on.
        /// </summary>
        public int port { get; }
        
        /// <summary>
        /// Opens the WebSocket server and starts listening for incoming connections.
        /// </summary>
        public void Open();
        
        /// <summary>
        /// Closes the WebSocket server and stops listening for incoming connections.
        /// </summary>
        public void Close();
        
        /// <summary>
        /// Sends a message to a specific client.
        /// </summary>
        /// <param name="clientId">The ID of the client to send the message to.</param>
        /// <param name="message">The message to be sent.</param>
        public void SendOne(IPEndPoint clientId, string message);
        
        /// <summary>
        /// Sends a message to multiple clients.
        /// </summary>
        /// <param name="clientIds">The IDs of the clients to send the message to.</param>
        /// <param name="message">The message to be sent.</param>
        public void SendMany(IPEndPoint[] clientIds, string message);
        
        /// <summary>
        /// Sends a message to all connected clients.
        /// </summary>
        /// <param name="message">The message to be sent.</param>
        public void SendAll(string message);
    }
}