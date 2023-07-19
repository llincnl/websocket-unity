using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebsocketUnity {
    
    public class WebsocketUnitySession : WebSocketBehavior, IWebsocketUnitySession {

        public event OnOpenSession OnOpenSession;
        public event OnCloseSession OnCloseSession;
        public event OnMessageSession OnMessageSession;

        protected override void OnOpen() {
            OnOpenSession?.Invoke(this);
        }

        protected override void OnClose(CloseEventArgs e) {
            OnCloseSession?.Invoke(this);
        }

        protected override void OnMessage(MessageEventArgs e) {
            OnMessageSession?.Invoke(this, e.Data);
        }
    }
}