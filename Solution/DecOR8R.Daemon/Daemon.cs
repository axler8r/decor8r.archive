using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DecOR8R.Daemon.Services;

namespace DecOR8R.Daemon;

public class Daemon
{
    public static int Main(string[] args)
    {
        try
        {
            CreateHostBuilder(args).Build().Run();
            return 0;
        }
        catch (Exception ex)
        {
            return 1;
        }
        finally
        {
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
            .ConfigureAppConfiguration((context, configurations) =>
            {
                var env_ = context.HostingEnvironment;
                configurations.AddJsonFile("appsettings.json");
                configurations.AddJsonFile($"appsettings.{env_.EnvironmentName}.json", optional: true);
            })
            .ConfigureLogging((context, loggers) => { })
            .ConfigureServices((context, services) =>
            {
                services.AddHostedService<ConfigurationService>();
                services.AddHostedService<Endpoint>();
            });
}
