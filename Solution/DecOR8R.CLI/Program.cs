using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace DecOR8R.CLI
{
    internal static class Program
    {
        private static readonly IDictionary<string, string> Payload = new Dictionary<string, string>();

        private static int Main(params string[] args)
        {
            var decor8R = new RootCommand
            {
                Decorate()
            };

            var invoke = decor8R.Invoke(args);

            var payload = new StringBuilder();
            foreach (var key in Payload.Keys) payload.AppendLine($"{key}={Payload[key]}");

            return Call(payload.ToString());
        }

        private static Command Decorate()
        {
            return new Command("decorate")
            {
                Terminal(),
                Tmux(),
                NeoVim()
            };
        }

        private static Command Terminal()
        {
            var result = new Command("terminal")
            {
                new Option<int>(
                    new[] {"-w", "--width"},
                    "Terminal width"),
                new Option<string>(
                    new[] {"-p", "--path"},
                    "Path to decorate")
            };
            result.Handler = CommandHandler.Create<int, string>(
                (width, path) =>
                {
                    Payload.Add("PAYLOAD", "TERMINAL");
                    Payload.Add("width", width.ToString());
                    Payload.Add("path", path);
                });

            return result;
        }

        private static Command Tmux()
        {
            return new Command("tmux");
        }

        private static Command NeoVim()
        {
            return new Command("neovim");
        }

        private static int Call(string path)
        {
            try
            {
                var address = Path.Combine(Path.GetTempPath(), "decor8r.sock");
                var endpoint = new UnixDomainSocketEndPoint(address);
                using var socket = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);
                socket.Connect(endpoint);

                var requestBytes = Encoding.UTF8.GetBytes(path);
                var request = Encoding.UTF8.GetString(requestBytes);
                socket.Send(requestBytes);

                var responseBytes = new byte[1024];
                var responseSize = socket.Receive(responseBytes);
                var response = Encoding.UTF8.GetString(responseBytes, 0, responseSize);

                Console.WriteLine($"RX ---------\n{request}TX ---------\n{response}");
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
