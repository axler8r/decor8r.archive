using DecOR8R.Daemon.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DecOR8R.Daemon;

public class Daemon
{
    public static int Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
        return 0;
        /*
        try
        {
            return 0;
        }
        catch (Exception ex)
        {
            return 1;
        }
        finally
        {
        }
        */
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
                configurations.AddJsonFile($"appsettings.{env_.EnvironmentName}.json", true);
            })
            .ConfigureLogging((context, loggers) => { })
            .ConfigureServices((context, services) =>
            {
                services.AddHostedService<ConfigurationService>();
                services.AddHostedService<Endpoint>();
            });
}
