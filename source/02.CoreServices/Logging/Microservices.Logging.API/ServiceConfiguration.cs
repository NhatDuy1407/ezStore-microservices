using Ws4vn.Microservicess.ApplicationCore.Interfaces;
using Ws4vn.Microservicess.ApplicationCore.SharedKernel;
using Ws4vn.Microservicess.Infrastructure.MongoDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Logging.API
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Add application services.
            services.AddTransient(i => new MongoDbContext(configuration.GetConnectionString(MicroservicesConstants.DefaultConnection), configuration.GetConnectionString(MicroservicesConstants.DefaultDatabaseName), false));
            services.AddTransient<IDataAccessReadOnlyService>(i => new ReadOnlyService(i.GetService<MongoDbContext>()));

            ApplicationCore.HandlerRegister.Register(services);
        }
    }
}