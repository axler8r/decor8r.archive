using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;


namespace DecOR8R.Daemon
{
    public class Daemon
    {
        // TODO: Move to configuration file
        private const string FILE_LOG_FORMAT =
            "[{Timestamp:yyyy-MM-ddTHH:mm:ss.ffK} {Level:u4}] " +
            "({SourceContext}) " +
            "{Message}{NewLine}{Exception}";

        // TODO: Move to configuration file
        private const string CONSOLE_LOG_FORMAT =
            "[{Level:u4}] ({SourceContext}) {Message}{NewLine}{Exception}";

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
#if DEBUG
                .WriteTo.Console(outputTemplate: CONSOLE_LOG_FORMAT)
#endif
                .WriteTo.File(
                    path: "decor8r.log",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: FILE_LOG_FORMAT)
                .CreateLogger();

            try
            {
                Log.ForContext<Daemon>().Information("Starting decor8rd");
                CreateHostBuilder(args).Build().Run();
                Log.ForContext<Daemon>().Information("Stopping decor8rd");
            }
            catch (Exception ex)
            {
                Log.ForContext<Daemon>().Fatal(ex, "Unable to run decor8rd");
                // PRINT AN ERROR MESSAGE
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, configurations) =>
                {
                    configurations.AddJsonFile("appsettings.json");
                })
#if Linux
                .UseSystemd()
#elif OSX
                .UseSystemd()
#elif Windows
                .UseWindowsService()
#endif
                .ConfigureLogging((context, loggers) =>
                {
                })
                .UseSerilog()
                .ConfigureServices((context, services) =>
                {
                    //services.AddHostedService<Worker>();
                    services.AddHostedService<ConfigurationService>();
                    services.AddHostedService<LoggingService>();
                    services.AddHostedService<EndpointService>();
                    services.AddHostedService<TerminalDecorationService>();
                    services.AddHostedService<TmuxDecorationService>();
                    services.AddHostedService<NeovimDecorationService>();
                });
    }
}
