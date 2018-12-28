using Ws4vn.Microservices.ApplicationCore.Interfaces;
using Ws4vn.Microservices.ApplicationCore.SharedKernel;
using Ws4vn.Microservices.Infrastructure.MongoDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microservices.FileSystem.ApplicationCore.Interfaces;
using Microservices.FileSystem.Infrastructure;

namespace Microservices.FileSystem.API
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Add application services.
            services.AddScoped(i => new MongoDbContext(configuration.GetConnectionString(MicroservicesConstants.DefaultConnection), configuration.GetConnectionString(MicroservicesConstants.DefaultDatabaseName), false));
            services.AddScoped(i => new MongoFsDbContext(configuration.GetConnectionString(MicroservicesConstants.DefaultConnection), configuration.GetConnectionString(MicroservicesConstants.DefaultDatabaseName), false));
            services.AddScoped<IDataAccessReadOnlyService>(i => new ReadOnlyService(i.GetService<MongoDbContext>()));
            services.AddScoped<IDataAccessWriteService>(i => new DataAccessWriteService(i.GetService<MongoDbContext>()));
            services.AddTransient<IFSRepository>(i => new FSRepository(i.GetService<MongoFsDbContext>()));
            
            ApplicationCore.HandlerRegister.Register(services);
        }
    }
}