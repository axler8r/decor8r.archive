using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace DecOR8R.Daemon.Services;

public class Transceiver : BackgroundService
{
    private readonly TerminalDecorator _decorator = new TerminalDecorator();
    private static readonly ILogger Log = Serilog.Log.ForContext<Transceiver>();
    private readonly IConfiguration _configuration;
    private readonly string _socketFile;

    public Transceiver(IConfiguration configuration, string socket = "decor8r.sock")
    {
        _configuration = configuration;
        _socketFile = Path.Combine(Path.GetTempPath(), socket);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (File.Exists(_socketFile)) File.Delete(_socketFile);

        var address = new UnixDomainSocketEndPoint(_socketFile);
        Log.Information($"Unix socket address: {address}.");

        using var listener = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);
        listener.Bind(address);
        listener.Listen();

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(0, stoppingToken);

            Log.Information("Ready to accept requests...");
            using var socket = await listener.AcceptAsync(stoppingToken);
            Log.Information($"Accepted request: {socket}.");

            var buffer = new byte[1024];
            var requestSize = socket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
            var request = Encoding.UTF8.GetString(buffer, 0, requestSize);
            Log.Information($"Received: {request}");

            var lines = request.Split("\n");
            string path = string.Empty;
            foreach (var line in lines)
            {
                if (line.StartsWith("path="))
                {
                     path = line.Replace("path=", string.Empty);

                }
            }

            string response = string.Empty;
            if (path.Length != 0)
            {
                response = _decorator.Decorate(path);
            }

            socket.Send(Encoding.UTF8.GetBytes(response.ToCharArray()));

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
