using Microservices.ApplicationCore.Interfaces;
using Microservices.ApplicationCore.SharedKernel;
using Microservices.Infrastructure.MongoDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Logging.API
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Add application services.
            services.AddTransient(i => new MongoDbContext(configuration.GetConnectionString(MicroserviceConstants.DefaultConnection), configuration.GetConnectionString(MicroserviceConstants.DefaultDatabaseName), false));
            services.AddTransient<IDataAccessReadOnlyService>(i => new ReadOnlyService(i.GetService<MongoDbContext>()));

            ApplicationCore.HandlerRegister.Register(services);
        }
    }
}