using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace DecOR8R.Daemon.Services;

internal class ConfigurationService : BackgroundService
{
    private readonly IConfiguration _applicationConfiguration;

    public ConfigurationService(IConfiguration configuration)
    {
        _applicationConfiguration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested) await Task.Delay(30000, stoppingToken);
    }
}
