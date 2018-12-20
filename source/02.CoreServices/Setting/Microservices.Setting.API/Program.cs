using Microservices.Setting.ApplicationCore.Services.Commands;
using Microservices.Setting.Infrastructure.Migration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace Microservices.Setting.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    DatabaseInitialization.InitializeDatabase(services);

                    var commandBus = services.GetRequiredService<ICommandBus>();
                    if (commandBus != null)
                    {
                        commandBus.ExecuteAsync(new CacheSettingCommand()).Wait();
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred Initializing the DB.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
