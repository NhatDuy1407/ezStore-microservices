using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Microservice.Logging.BackgroundProcess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            Task.Factory.StartNew(() =>
            {
                var requestService = new UserRequestService(configuration);
                requestService.Start();
            });

            Thread.Sleep(Timeout.Infinite);
        }
    }
}