using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using DecOR8R.Daemon.Services;

namespace DecOR8R.Daemon;

public class Daemon
{
    public static int Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("Configuration/logsettings.json")
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
                var env_ = context.HostingEnvironment;
                configurations.AddJsonFile("Configuration/appsettings.json");
                configurations.AddJsonFile($"Configuration/appsettings.{env_.EnvironmentName}.json");
            })
            .ConfigureLogging((context, loggers) => { })
            .ConfigureServices((context, services) =>
            {
                services.AddHostedService<Endpoint>();
                //services.AddHostedService<ConfigurationService>();
            });
}
