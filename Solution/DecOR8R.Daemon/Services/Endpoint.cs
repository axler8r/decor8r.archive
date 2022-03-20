using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

using DecOR8R.Daemon.Decorators.Terminal;

namespace DecOR8R.Daemon.Services;

// TODO: Rename to EndpointService
class Endpoint : BackgroundService
{
    private readonly TerminalDecorator _decorator = new TerminalDecorator();
    private static readonly ILogger Log = Serilog.Log.ForContext<Endpoint>();
    private readonly IConfiguration _configuration;
    private readonly string _socketFile;

    public Endpoint(IConfiguration configuration, string socket = "decor8r.sock")
    {
        _configuration = configuration;
        _socketFile = Path.Combine(Path.GetTempPath(), socket);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (File.Exists(_socketFile)) File.Delete(_socketFile);

        var address_ = new UnixDomainSocketEndPoint(_socketFile);
        Log.Information($"Unix socket address: {address_}.");

        using var listener_ = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);
        listener_.Bind(address_);
        listener_.Listen();

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(0, stoppingToken);

            Log.Information("Ready to accept requests...");
            using var socket_ = await listener_.AcceptAsync(stoppingToken);
            Log.Information($"Accepted request: {socket_}.");

            var buffer_ = new byte[1024];
            var requestSize_ = socket_.Receive(buffer_, 0, buffer_.Length, SocketFlags.None);
            var request_ = Encoding.UTF8.GetString(buffer_, 0, requestSize_);
            Log.Information($"Received: {request_}");

            var lines_ = request_.Split("\n");
            string path_ = string.Empty;
            foreach (var line_ in lines_)
            {
                if (line_.StartsWith("path="))
                {
                     path_ = line_.Replace("path=", string.Empty);

                }
            }

            string response_ = string.Empty;
            if (path_.Length != 0)
            {
                response_ = _decorator.Decorate(path_);
            }

            socket_.Send(Encoding.UTF8.GetBytes(response_.ToCharArray()));

            socket_.Shutdown(SocketShutdown.Both);
            socket_.Close();
        }
    }
}
