using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;


namespace DecOR8R.Daemon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                //.Enrich.FromLogContext()
                #if DEBUG
                .WriteTo.Console()
                #endif
                .WriteTo.File(
                    path: "log.log",
                    rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                Log.Information("Starting DecOR8R.Daemon.Program");
                CreateHostBuilder(args).Build().Run();
                Log.Information("Stopping DecOR8R.Daemon.Program");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unable to run service");
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
                .ConfigureAppConfiguration((context, configurations) => {
                    configurations.AddJsonFile("appsettings.json");
                })
                #if Linux
                .UseSystemd()
                #elif OSX
                .UseSystemd()
                #elif Windows
                .UseWindowsService()
                #endif
                .ConfigureLogging((context, loggers) => {
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
