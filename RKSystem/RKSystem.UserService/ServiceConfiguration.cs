using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RKSystem.DataAccess.MongoDB;
using RKSystem.DataAccess.MongoDB.Interfaces;
using RKSystem.Service.Core;
using RKSystem.UserService.Interfaces;
using RKSystem.UserService.Models.Commands;

namespace RKSystem.UserService
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Add application services.
            services.AddTransient(i => new MongoDbContext(configuration.GetConnectionString("DefaultConnection"), configuration.GetConnectionString("DefaultDatabaseName"), false));
            services.AddTransient<IReadOnlyUnitOfWork>(i => new ReadOnlyUnitOfWork(i.GetService<MongoDbContext>()));
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<ICommandHandler<CreateUserCommand>, CommandService>();
        }
    }
}
