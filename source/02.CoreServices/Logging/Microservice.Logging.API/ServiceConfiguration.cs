using Microservice.Core;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.DataAccess.MongoDB;
using Microservice.Logging.Domain.Application.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Logging.API
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Add application services.
            services.AddTransient<ILoggingQueries, LoggingQueries>();
            services.AddTransient(i => new MongoDbContext(configuration.GetConnectionString(Constants.DefaultConnection), configuration.GetConnectionString(Constants.DefaultDatabaseName), false));
            services.AddTransient<IDataAccessReadOnlyService>(i => new ReadOnlyService(i.GetService<MongoDbContext>()));
        }
    }
}