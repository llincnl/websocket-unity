using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace WebsocketUnity {
    
    /// <summary>
    /// Provides utility functions for the WebSocket Unity library.
    /// </summary>
    public static class WebsocketUnityUtils {
        
        /// <summary>
        /// Retrieves the local IP address of the device.
        /// </summary>
        /// <returns>Returns a string representation of the local IP address. Returns null if no appropriate local IP address is found.</returns>
        public static string GetLocalAddress() {
            var address = NetworkInterface
                .GetAllNetworkInterfaces()
                .SelectMany(n => n.GetIPProperties().UnicastAddresses)
                .Where(a => a.Address.AddressFamily == AddressFamily.InterNetwork)
                .Select(a => a.Address)
                .FirstOrDefault(a => a.ToString().StartsWith("192.") || a.ToString().StartsWith("172.") || a.ToString().StartsWith("145.") || a.ToString().StartsWith("10."));

            if (address != null) {
                return address.ToString();
            } else {
                address = NetworkInterface
                    .GetAllNetworkInterfaces()
                    .SelectMany(n => n.GetIPProperties().UnicastAddresses)
                    .Where(a => a.Address.AddressFamily == AddressFamily.InterNetwork)
                    .Select(a => a.Address)
                    .FirstOrDefault(a => a.ToString().StartsWith("145."));

                if (address != null) {
                    return address.ToString();
                }
                else {
                    return null;
                }
            }
        }
    }
}