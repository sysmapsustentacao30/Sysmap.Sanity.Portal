using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using System;

namespace Sysmap.Portal.Sanity
{
    public class Program
    {
        public static void Main(string[] args)
        {            
            // Configure Serilog for logging
            Log.Logger = new LoggerConfiguration()
           .Enrich.FromLogContext()
           .WriteTo.Console()
           .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
           .CreateLogger();

            try
            {
                Log.Information("Starting Amplifier web host");
                BuildWebHost(args).Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog()
                .Build();
    }
}
