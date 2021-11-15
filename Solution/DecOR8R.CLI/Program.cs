using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace DecOR8R.CLI
{
    internal static class Program
    {
        private static int Main(params string[] args)
        {
            try
            {
                var address = Path.Combine(Path.GetTempPath(), "decor8r.sock");
                var endpoint = new UnixDomainSocketEndPoint(address);
                using var socket = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);
                socket.Connect(endpoint);

                var requestBytes = Encoding.UTF8.GetBytes("Hello!");
                var request = Encoding.UTF8.GetString(requestBytes);
                socket.Send(requestBytes);

                var responseBytes = new byte[1024];
                var responseSize = socket.Receive(responseBytes);
                var response = Encoding.UTF8.GetString(responseBytes, 0, responseSize);

                Console.WriteLine($"Sent {request}, got {response}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 1;
            }

            return 0;
        }
    }
}
