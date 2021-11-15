using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DecOR8R.Daemon.Services
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _socketFile;

        public Worker(ILogger<Worker> logger, IConfiguration configuration, string socket = "decor8r.sock")
        {
            _logger = logger;
            _configuration = configuration;
            _socketFile = Path.Combine(Path.GetTempPath(), socket);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (File.Exists(_socketFile)) File.Delete(_socketFile);

            var address = new UnixDomainSocketEndPoint(_socketFile);
            _logger.LogInformation($"Unix socket address: {address}.");

            using (var listener = new Socket(
                AddressFamily.Unix,
                SocketType.Stream,
                ProtocolType.Unspecified))
            {
                listener.Bind(address);
                listener.Listen();
                _logger.LogInformation($"Started listener: {listener}.");

                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(0, stoppingToken);

                    _logger.LogInformation("Ready to accept requests...");
                    using var socket = await listener.AcceptAsync(stoppingToken);
                    _logger.LogInformation($"Accepted request: {socket}.");

                    var buffer = new byte[1024];
                    var requestSize = socket.Receive(
                        buffer,
                        0,
                        buffer.Length,
                        SocketFlags.None);
                    var request = Encoding.UTF8.GetString(buffer, 0, requestSize);
                    _logger.LogInformation($"Received: {request}");

                    socket.Send(Encoding.UTF8.GetBytes(request.ToCharArray()));
                    _logger.LogInformation("Sent response.");

                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
            }
        }
    }
}
