using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.Service;
using Microservice.Logging.API.Application.Commands;
using Microservice.Logging.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Logging.API
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Add application services.
            services.AddTransient(i => new LoggingContext(configuration.GetConnectionString("DefaultConnection"), configuration.GetConnectionString("DefaultDatabaseName"), false));
            services.AddTransient<IReadOnlyService>(i => new ReadOnlyService(i.GetService<LoggingContext>()));

            services.AddTransient<ICommandHandler<AddExceptionLogCommand>, ExceptionLogCommandHandler>();
        }
    }
}