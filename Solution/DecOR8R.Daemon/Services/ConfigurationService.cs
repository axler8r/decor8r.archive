using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using Serilog;

namespace DecOR8R.Daemon.Services
{
    class ConfigurationService : BackgroundService
    {
        private readonly IConfiguration _applicationConfiguration;
        private readonly IConfiguration _userConfiguration;
        private readonly IConfiguration _styleConfiguration;
        private readonly IConfiguration _themeConfiguration;

        private static readonly ILogger Log = Serilog.Log.ForContext<ConfigurationService>();

        public ConfigurationService(IConfiguration configuration)
        {
            _applicationConfiguration = configuration;
            _userConfiguration = LoadUserConfiguration();
            //_styleConfiguration = LoadStyleConfiguration();
            //_themeConfiguration = LoadThemeConfiguration();
        }

        // TODO: Exception?
        private IConfiguration LoadUserConfiguration()
        {
            var path_ = _applicationConfiguration
                .GetSection("Configuration:User")
                .GetValue<string>("Path");
            var file_ = _applicationConfiguration
                .GetSection("Configuration:User")
                .GetValue<string>("File");
            var configFile_ = Path.Join(path_, file_);
            Log.Information($"Configuration file is: {configFile_}");

            return new ConfigurationBuilder().AddJsonFile(configFile_).Build();
        }

        private IConfiguration LoadStyleConfiguration()
        {
            throw new NotImplementedException();
        }

        private IConfiguration LoadThemeConfiguration()
        {
            throw new NotImplementedException();
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Log.Information($"Starting {GetType().Name}...");
            return base.StartAsync(cancellationToken);
        }

        private string TranslateEnvironmentVariableFormat(string s)
        {
            return s.Replace("${", "%").Replace("}", "%");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested) await Task.Delay(30000, stoppingToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Log.Information($"Stopping {GetType().Name}...");
            return base.StopAsync(cancellationToken);
        }
    }
}
