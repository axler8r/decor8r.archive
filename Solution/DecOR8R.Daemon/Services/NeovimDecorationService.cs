using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Serilog;


namespace DecOR8R.Daemon
{
    public class NeovimDecorationService : BackgroundService
    {
        public NeovimDecorationService()
        {
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Log.Information($"Starting {this.GetType().Name}...");
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
            Log.Information($"Stopping {this.GetType().Name}...");
            return base.StopAsync(cancellationToken);
        }
    }
}
