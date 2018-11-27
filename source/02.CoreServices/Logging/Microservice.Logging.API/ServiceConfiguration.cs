using Microservice.Core;
using Microservice.Logging.Domain.Application.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microservice.DataAccess.Core.Interfaces;
using Microservice.DataAccess.MongoDB;

namespace Microservice.Logging.API
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Add application services.
            services.AddTransient(i => new MongoDbContext(configuration.GetConnectionString(MicroserviceConstants.DefaultConnection), configuration.GetConnectionString(MicroserviceConstants.DefaultDatabaseName), false));
            services.AddTransient<IDataAccessReadOnlyService>(i => new ReadOnlyService(i.GetService<MongoDbContext>()));

            Domain.HandlerRegister.Register(services);
        }
    }
}