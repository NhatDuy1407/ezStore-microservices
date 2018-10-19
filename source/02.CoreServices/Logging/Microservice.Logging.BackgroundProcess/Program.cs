using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Microservice.Logging.BackgroundProcess
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
               .UseStartup<Startup>()
               .Build();
    }
}