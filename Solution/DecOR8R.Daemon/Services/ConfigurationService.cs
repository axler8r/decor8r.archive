using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace DecOR8R.Daemon.Services
{
    class ConfigurationService : BackgroundService
    {
        private readonly IConfiguration _applicationConfiguration;

        public ConfigurationService(IConfiguration configuration)
        {
            _applicationConfiguration = configuration;
            LoadUserConfiguration();
            //_styleConfiguration = LoadStyleConfiguration();
            //_themeConfiguration = LoadThemeConfiguration();
        }

        // TODO: Exception?
        private void LoadUserConfiguration()
        {
            var path_ = _applicationConfiguration
                .GetSection("Configuration:User")
                .GetValue<string>("Path");
            var file_ = _applicationConfiguration
                .GetSection("Configuration:User")
                .GetValue<string>("File");
            var configFile_ = Path.Join(path_, file_);

            new ConfigurationBuilder().AddJsonFile(configFile_).Build();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested) await Task.Delay(30000, stoppingToken);
        }
    }
}
