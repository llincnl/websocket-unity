namespace WebsocketUnity {
    
    /// <summary>
    /// Delegate for a WebSocket session open event.
    /// </summary>
    /// <param name="session">The session that was opened.</param>
    public delegate void OnOpenSession(WebsocketUnitySession session);
    
    /// <summary>
    /// Delegate for a WebSocket session close event.
    /// </summary>
    /// <param name="session">The session that was closed.</param>
    public delegate void OnCloseSession(WebsocketUnitySession session);
    
    /// <summary>
    /// Delegate for a WebSocket session message event.
    /// </summary>
    /// <param name="session">The session that the message was sent to.</param>
    /// <param name="message">The message that was received.</param>
    public delegate void OnMessageSession(WebsocketUnitySession session, string message);
    
    /// <summary>
    /// Interface for a WebSocket session.
    /// </summary>
    public interface IWebsocketUnitySession {
        
        /// <summary>
        /// Event triggered when a WebSocket session opens.
        /// </summary>
        public event OnOpenSession OnOpenSession;
        
        /// <summary>
        /// Event triggered when a WebSocket session closes.
        /// </summary>
        public event OnCloseSession OnCloseSession;
        
        /// <summary>
        /// Event triggered when a WebSocket session receives a message.
        /// </summary>
        public event OnMessageSession OnMessageSession;
    }
}