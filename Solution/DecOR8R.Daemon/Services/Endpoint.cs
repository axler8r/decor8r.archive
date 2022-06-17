using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DecOR8R.Daemon.Decorators.Terminal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DecOR8R.Daemon.Services;

// TODO: Rename to EndpointService
internal class Endpoint : BackgroundService
{
    private readonly IConfiguration _configuration;
    private readonly TerminalDecorator _decorator = new();
    private readonly ILogger<Endpoint> _logger;
    private readonly string _socketFile;

    public Endpoint(ILogger<Endpoint> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _socketFile = Path.Combine(Path.GetTempPath(), "decor8r.sock");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (File.Exists(_socketFile)) File.Delete(_socketFile);

        var address_ = new UnixDomainSocketEndPoint(_socketFile);

        using var listener_ = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);
        listener_.Bind(address_);
        listener_.Listen();

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(0, stoppingToken);

            using var socket_ = await listener_.AcceptAsync(stoppingToken);

            var buffer_ = new byte[1024];
            var requestSize_ = socket_.Receive(buffer_, 0, buffer_.Length, SocketFlags.None);
            var request_ = Encoding.UTF8.GetString(buffer_, 0, requestSize_);

            var lines_ = request_.Split("\n");
            var path_ = string.Empty;
            foreach (var line_ in lines_)
                if (line_.StartsWith("path="))
                    path_ = line_.Replace("path=", string.Empty);

            var response_ = string.Empty;
            if (path_.Length != 0) response_ = _decorator.Decorate(path_);

            socket_.Send(Encoding.UTF8.GetBytes(response_.ToCharArray()));

            socket_.Shutdown(SocketShutdown.Both);
            socket_.Close();
        }
    }
}
