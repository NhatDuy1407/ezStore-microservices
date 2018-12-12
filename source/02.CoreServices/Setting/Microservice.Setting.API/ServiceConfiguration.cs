using MassTransit;
using MassTransit.Util;
using Microservices.ApplicationCore.Interfaces;
using Microservices.ApplicationCore.Services;
using Microservices.ApplicationCore.SharedKernel;
using Microservices.ApplicationCore.Validations;
using Microservices.Infrastructure;
using Microservices.Infrastructure.MongoDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microservice.Setting.API
{
    public static class ServiceConfiguration
    {
        private static IBusControl _bus;

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(i =>
            {
                if (_bus == null)
                {
                    _bus = Bus.Factory.CreateUsingRabbitMq(x =>
                    {
                        var username = configuration.GetConnectionString(MicroserviceConstants.RabbitMQUsername);
                        var password = configuration.GetConnectionString(MicroserviceConstants.RabbitMQPassword);
                        var host = configuration.GetConnectionString(MicroserviceConstants.RabbitMQHost);
                        if (!string.IsNullOrEmpty(host))
                        {
                            x.Host(new Uri(host), h =>
                            {
                                if (!string.IsNullOrEmpty(username))
                                {
                                    h.Username(configuration.GetConnectionString(MicroserviceConstants.RabbitMQUsername));
                                }
                                if (!string.IsNullOrEmpty(password))
                                {
                                    h.Password(configuration.GetConnectionString(MicroserviceConstants.RabbitMQPassword));
                                }

                            });
                        }
                    });
                    TaskUtil.Await(() => _bus.StartAsync());
                }
                return _bus;
            });

            services.AddScoped<IValidationContext, ValidationContext>();
            services.AddTransient<ICommandBus, CommandBus>();
            services.AddTransient<IEventBus, EventBus>();

            // Add application services.
            services.AddTransient<IDomainContext>(i => new DomainContext(i.GetService<IConfiguration>(), i.GetService<IBusControl>(), i.GetService<IEventBus>()));
            services.AddTransient(i => new MongoDbContext(configuration.GetConnectionString(MicroserviceConstants.SettingDbConnection), configuration.GetConnectionString(MicroserviceConstants.SettingDbName), false));
            services.AddTransient<IDataAccessService>(i => new DataAccessWriteService(i.GetService<MongoDbContext>()));
            services.AddTransient<IDataAccessWriteService>(i => new DataAccessWriteService(i.GetService<MongoDbContext>()));
            services.AddTransient<IDomainService>(i => new DomainService(i.GetService<IDomainContext>(), i.GetService<IDataAccessWriteService>()));
            services.AddTransient<IDataAccessReadOnlyService>(i => new ReadOnlyService(i.GetService<MongoDbContext>()));

            ApplicationCore.HandlerRegister.Register(services);
        }
    }
}
