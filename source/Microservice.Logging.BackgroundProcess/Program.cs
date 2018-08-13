using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Microservice.Logging.BackgroundProcess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(Path.Combine(AppContext.BaseDirectory))
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //    .AddJsonFile($"appsettings.Local.json", optional: true)
            //    .AddEnvironmentVariables();

            //var configuration = builder.Build();

            //Task.Factory.StartNew(() =>
            //{
            //    var requestService = new ComsummerService(configuration);
            //    requestService.Start();
            //});

            //Thread.Sleep(Timeout.Infinite);
        }

        public static IWebHost BuildWebHost(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
               .UseStartup<Startup>()
               .Build();
    }
}