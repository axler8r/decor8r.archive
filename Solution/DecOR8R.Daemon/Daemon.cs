using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;


namespace DecOR8R.Daemon
{
    public class Daemon
    {
        public static int Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .Build();
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                Log.ForContext<Daemon>().Information("Starting decor8rd");
                CreateHostBuilder(args).Build().Run();
                Log.ForContext<Daemon>().Information("Stopping decor8rd");
                return 0;
            }
            catch (Exception ex)
            {
                Log.ForContext<Daemon>().Fatal(ex, "Unable to run decor8rd");
                // PRINT AN ERROR MESSAGE
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
#if Linux
                .UseSystemd()
#elif OSX
                .UseSystemd()
#elif Windows
                .UseWindowsService()
#endif
                .UseSerilog()
                .ConfigureAppConfiguration((context, configurations) =>
                {
                    var env = context.HostingEnvironment;
                    configurations.AddJsonFile("appsettings.json");
                    configurations.AddJsonFile($"appsettings.{env.EnvironmentName}.json");
                })
                .ConfigureLogging((context, loggers) =>
                {
                })
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
