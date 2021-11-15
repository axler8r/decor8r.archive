using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace DecOR8R.Daemon.Services
{
    public class LoggingService : BackgroundService
    {
        private static readonly ILogger Log = Serilog.Log.ForContext<LoggingService>();

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Log.Information($"Starting {GetType().Name}...");
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(30000, stoppingToken);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Log.Information($"Stopping {GetType().Name}...");
            return base.StopAsync(cancellationToken);
        }
    }
}
