namespace WebsocketUnity {
    
    /// <summary>
    /// Delegate for a WebSocket client connect event.
    /// </summary>
    public delegate void OnConnectWebsocketClient();
    
    /// <summary>
    /// Delegate for a WebSocket client disconnect event.
    /// </summary>
    public delegate void OnDisconnectWebsocketClient();
    
    /// <summary>
    /// Delegate for a WebSocket client message event.
    /// </summary>
    /// <param name="message">The message received from the WebSocket server.</param>
    public delegate void OnMessageWebsocketClient(string message);
    
    /// <summary>
    /// Interface for a WebSocket client.
    /// </summary>
    public interface IWebsocketUnityClient {

        /// <summary>
        /// Event triggered when the WebSocket client connects to a server.
        /// </summary>
        public event OnConnectWebsocketClient OnConnect;
        
        /// <summary>
        /// Event triggered when the WebSocket client disconnects from a server.
        /// </summary>
        public event OnDisconnectWebsocketClient OnDisconnect;
        
        /// <summary>
        /// Event triggered when the WebSocket client receives a message from a server.
        /// </summary>
        public event OnMessageWebsocketClient OnMessage;
        
        /// <summary>
        /// Opens a connection to a WebSocket server.
        /// </summary>
        /// <param name="url">The URL of the WebSocket server.</param>
        public void Open(string url);
        
        /// <summary>
        /// Closes the connection to the WebSocket server.
        /// </summary>
        public void Close();
        
        /// <summary>
        /// Sends a message to the WebSocket server.
        /// </summary>
        /// <param name="message">The message to be sent.</param>
        public void Send(string message);
    }
}