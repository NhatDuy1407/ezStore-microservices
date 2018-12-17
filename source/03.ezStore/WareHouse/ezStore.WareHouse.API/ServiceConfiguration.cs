using ezStore.WareHouse.Infrastructure;
using MassTransit;
using MassTransit.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Ws4vn.Microservicess.ApplicationCore.Interfaces;
using Ws4vn.Microservicess.ApplicationCore.SharedKernel;
using Ws4vn.Microservicess.Infrastructure.Caching;
using Ws4vn.Microservicess.Infrastructure.Sql;

namespace ezStore.WareHouse.API
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
                        var username = configuration.GetConnectionString(MicroservicesConstants.RabbitMQUsername);
                        var password = configuration.GetConnectionString(MicroservicesConstants.RabbitMQPassword);
                        var host = configuration.GetConnectionString(MicroservicesConstants.RabbitMQHost);
                        if (!string.IsNullOrEmpty(host))
                        {
                            x.Host(new Uri(host), h =>
                            {
                                if (!string.IsNullOrEmpty(username))
                                {
                                    h.Username(configuration.GetConnectionString(MicroservicesConstants.RabbitMQUsername));
                                }
                                if (!string.IsNullOrEmpty(password))
                                {
                                    h.Password(configuration.GetConnectionString(MicroservicesConstants.RabbitMQPassword));
                                }

                            });
                        }
                    });
                    TaskUtil.Await(() => _bus.StartAsync());
                }
                return _bus;
            });

            // Add application services.
            services.AddTransient<IDataAccessService>(i => new DataAccessWriteService(i.GetService<WareHouseDbContext>()));
            services.AddTransient<IDataAccessWriteService>(i => new DataAccessWriteService(i.GetService<WareHouseDbContext>()));
            services.AddTransient<IDataAccessReadOnlyService>(i => new DataAccessReadOnlyService(i.GetService<WareHouseDbContext>()));
            services.AddTransient<ICacheService>(i => new RedisCacheService(configuration.GetConnectionString(MicroservicesConstants.RedisAddress)));
            services.AddScoped<IReadModelRepository>(i => new ReadModelService(i.GetService<ICacheService>()));

            ApplicationCore.HandlerRegister.Register(services);
        }
    }
}
