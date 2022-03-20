namespace DecOR8R.CLI;

using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Net.Sockets;
using System.Text;

internal static class Program
{
    private static readonly IDictionary<string, string> Payload = new Dictionary<string, string>();

    private static int Main(params string[] args)
    {
        var decor8R_ = new RootCommand
        {
            Decorate()
        };

        var invoke_ = decor8R_.Invoke(args);
        if (invoke_ != 0) return invoke_;

        var payload_ = new StringBuilder();
        foreach (var key_ in Payload.Keys) payload_.AppendLine($"{key_}={Payload[key_]}");

        return Call(payload_.ToString());
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
        var result_ = new Command("terminal")
        {
            new Option<int>(
                new[] {"-w", "--width"},
                "Terminal width"),
            new Option<string>(
                new[] {"-p", "--path"},
                "Path to decorate")
        };
        result_.Handler = CommandHandler.Create<int, string>(
            (width, path) =>
            {
                Payload.Add("PAYLOAD", "TERMINAL");
                Payload.Add("width", width.ToString());
                Payload.Add("path", path);
            });

        return result_;
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
            var address_ = Path.Combine(Path.GetTempPath(), "decor8r.sock");
            var endpoint_ = new UnixDomainSocketEndPoint(address_);
            using var socket_ = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);
            socket_.Connect(endpoint_);

            var requestBytes_ = Encoding.UTF8.GetBytes(path);
            var request_ = Encoding.UTF8.GetString(requestBytes_);
            socket_.Send(requestBytes_);

            var responseBytes_ = new byte[1024];
            var responseSize_ = socket_.Receive(responseBytes_);
            var response_ = Encoding.UTF8.GetString(responseBytes_, 0, responseSize_);

            Console.WriteLine($"RX ---------\n{request_}TX ---------\n{response_}");
        }
        catch (Exception e_)
        {
            Console.WriteLine(e_);
            return 1;
        }

        return 0;
    }
}
