using System.Buffers;
using System.IO;
using System.IO.Pipelines;
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
            if (File.Exists(_socketFile)) File.Delete(_socketFile);

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

                        var pipe_ = new Pipe();
                        var filled_ = Fill(socket_, pipe_.Writer);
                        var flushed_ = Flush(pipe_.Reader);
                        await Task.WhenAll(flushed_, filled_);

                        socket_.Shutdown(SocketShutdown.Both);
                        socket_.Close();
                    }
                }
            }
        }

        private async Task Fill(Socket socket, PipeWriter writer)
        {
            const int initialBufferSize_ = 512;

            while (true)
            {
                System.Memory<byte> memory_ = writer.GetMemory(initialBufferSize_);
                try
                {
                    int bytesReceived_ = await socket.ReceiveAsync(memory_, SocketFlags.None);
                    if (bytesReceived_ == 0) break;
                    writer.Advance(bytesReceived_);
                }
                catch (System.Exception e)
                {
                    _logger.LogError($"Exception: {e}");
                    break;
                }
                var result_ = await writer.FlushAsync();
                if (result_.IsCompleted) break;
            }

            await writer.CompleteAsync();
        }

        private async Task Flush(PipeReader reader)
        {
            while (true)
            {
                ReadResult result_ = await reader.ReadAsync();
                ReadOnlySequence<byte> buffer_ = result_.Buffer;

                while (TryReadLine(ref buffer_, out ReadOnlySequence<byte> line))
                {
                    ProcessLine(line);
                }

                reader.AdvanceTo(buffer_.Start, buffer_.End);
                if (result_.IsCompleted) break;
            }

            await reader.CompleteAsync();
        }

        private bool TryReadLine(ref ReadOnlySequence<byte> buffer, out ReadOnlySequence<byte> line)
        {
            System.SequencePosition? lookForEOL_ = buffer.PositionOf((byte)'\n');

            if (lookForEOL_ == null)
            {
                line = default;
                return false;
            }

            line = buffer.Slice(0, lookForEOL_.Value);
            buffer = buffer.Slice(buffer.GetPosition(1, lookForEOL_.Value));
            return true;
        }

        private void ProcessLine(ReadOnlySequence<byte> line)
        {
            var request_ = Encoding.UTF8.GetString(line);
            _logger.LogInformation(request_);
        }
    }
}
