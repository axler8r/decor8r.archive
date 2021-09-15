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

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, configurations) => {
                    configurations.AddJsonFile("appsettings.json");
                })
                #if Linux
                .UseSystemd()
                .ConfigureLogging((context, loggers) => {
                })
                .UseSerilog()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
