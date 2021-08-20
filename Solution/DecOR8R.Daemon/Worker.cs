using System.IO;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace DecOR8R.Daemon
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
            if (File.Exists(_socketFile))
            {
               File.Delete(_socketFile); 
            }

            var address_ = new UnixDomainSocketEndPoint(_socketFile);
            _logger.LogInformation($"Unix socket address: {address_}.");

            using (var listener_ = new Socket(
                addressFamily: AddressFamily.Unix,
                socketType: SocketType.Stream,
                protocolType: ProtocolType.Unspecified))
            {
                listener_.Bind(address_);
                listener_.Listen();
                _logger.LogInformation($"Started listner: {listener_.ToString()}.");

                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(0, stoppingToken);

                    _logger.LogInformation("Ready to accept requests...");
                    using (var socket_ = listener_.Accept())
                    {
                        _logger.LogInformation($"Accepped request: {socket_.ToString()}.");

                        var buffer_ = new byte[1024];
                        var requestSize_ = socket_.Receive(
                            buffer: buffer_,
                            offset: 0,
                            size: buffer_.Length,
                            socketFlags: SocketFlags.None);
                        var request_ = Encoding.UTF8.GetString(buffer_, 0, requestSize_);
                        _logger.LogInformation($"Receved: {request_}");

                        socket_.Shutdown(SocketShutdown.Both);
                        socket_.Close();
                    }
                }
            }
        }
    }
}
