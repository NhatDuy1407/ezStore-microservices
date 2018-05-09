using System;
using MassTransit;
using Microservice.Core.DataAccess.MongoDB;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microservice.Service.UserService.Interfaces;
using Microservice.Service.UserService.Models.Commands;
using MassTransit.Util;

namespace Microservice.Service.UserService
{
    public static class ServiceConfiguration
    {
        static IBusControl bus;
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Add application services.
            services.AddTransient(i => new MongoDbContext(configuration.GetConnectionString("DefaultConnection"), configuration.GetConnectionString("DefaultDatabaseName"), false));
            services.AddTransient<IReadOnlyService>(i => new ReadOnlyService(i.GetService<MongoDbContext>()));
            services.AddTransient<IUserService, UserService>();

            services.AddTransient(i =>
            {
                if (bus == null)
                {
                    bus = Bus.Factory.CreateUsingRabbitMq(x =>
                    {
                        x.Host(new Uri(configuration.GetConnectionString("RabbitMQHost")), h =>
                        {
                            //h.Username("guest");
                            //h.Password("guest");
                        });
                    });
                    TaskUtil.Await(() => bus.StartAsync());
                }
                return bus;
            });

            services.AddTransient<ICommandHandler<CreateUserCommand>, CommandUserService>();
        }
    }
}
