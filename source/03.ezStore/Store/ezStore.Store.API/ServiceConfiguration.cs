﻿using ezStore.WareHouse.Infrastructure;
using MassTransit;
using MassTransit.Util;
using Microservice.Core;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.DataAccess.Sql;
using Microservice.Core.DomainService;
using Microservice.Core.DomainService.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ezStore.WareHouse.API
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
                        x.Host(new Uri(configuration.GetConnectionString(MicroserviceConstants.RabbitMQHost)), h =>
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
                    });
                    TaskUtil.Await(() => _bus.StartAsync());
                }
                return _bus;
            });

            services.AddTransient<ICommandBus, CommandBus>();

            // Add application services.
            services.AddTransient<IDomainContext>(i => new DomainContext(i.GetService<IConfiguration>(), i.GetService<IBusControl>()));
            services.AddTransient<IDataAccessWriteService>(i => new DataAccessWriteService(i.GetService<WareHouseDbContext>()));
            services.AddTransient<IDomainService>(i => new DomainService(i.GetService<IDomainContext>(), i.GetService<IDataAccessWriteService>()));
            services.AddTransient<IDataAccessReadOnlyService>(i => new DataAccessReadOnlyService(i.GetService<WareHouseDbContext>()));

            Domain.HandlerRegister.Register(services);
        }
    }
}
