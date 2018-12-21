using MassTransit;
using MassTransit.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using Ws4vn.Microservices.ApplicationCore.SharedKernel;
using Ws4vn.Microservices.Infrastructure.Caching;
using Ws4vn.Microservices.Infrastructure.MongoDB;
using Ws4vn.Microservices.Infrastructure.RabbitMQ;

namespace Microservices.Setting.API
{
    public static class ServiceConfiguration
    {
        private static IBusControl _bus;

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(i =>
            {
                if (_bus == null)
                {
                    _bus = Bus.Factory.CreateUsingRabbitMq(x =>
                    {
                        var username = configuration.GetConnectionString(MicroservicesConstants.MessageBusUsername);
                        var password = configuration.GetConnectionString(MicroservicesConstants.MessageBusPassword);
                        var host = configuration.GetConnectionString(MicroservicesConstants.MessageBusHost);
                        if (!string.IsNullOrEmpty(host))
                        {
                            x.Host(new Uri(host), h =>
                            {
                                if (!string.IsNullOrEmpty(username))
                                {
                                    h.Username(configuration.GetConnectionString(MicroservicesConstants.MessageBusUsername));
                                }
                                if (!string.IsNullOrEmpty(password))
                                {
                                    h.Password(configuration.GetConnectionString(MicroservicesConstants.MessageBusPassword));
                                }

                            });
                        }
                    });
                    TaskUtil.Await(() => _bus.StartAsync());
                }
                return _bus;
            });
            services.AddScoped<IMessageBus, MessageBus>();

            // Add application services.
            services.AddScoped(i => new MongoDbContext(configuration.GetConnectionString(MicroservicesConstants.SettingDbConnection), configuration.GetConnectionString(MicroservicesConstants.SettingDbName), false));
            services.AddTransient<IDataAccessService>(i => new DataAccessWriteService(i.GetService<MongoDbContext>()));
            services.AddTransient<IDataAccessWriteService>(i => new DataAccessWriteService(i.GetService<MongoDbContext>()));
            services.AddTransient<IDataAccessReadOnlyService>(i => new ReadOnlyService(i.GetService<MongoDbContext>()));

            services.AddTransient<ICacheService>(i => new RedisCacheService(configuration.GetConnectionString(MicroservicesConstants.RedisAddress)));
            services.AddScoped<IReadModelRepository>(i => new ReadModelService(i.GetService<ICacheService>()));
            
            ApplicationCore.HandlerRegister.Register(services);
        }
    }
}
