using ezStore.Product.Domain;
using ezStore.Product.Domain.Application.CommandHandlers;
using ezStore.Product.Domain.Application.Commands;
using ezStore.Product.Domain.Application.Queries;
using ezStore.Product.Infrastructure;
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

namespace ezStore.Product.API
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
                        var username = configuration.GetConnectionString(Constants.RabbitMQUsername);
                        var password = configuration.GetConnectionString(Constants.RabbitMQPassword);
                        x.Host(new Uri(configuration.GetConnectionString(Constants.RabbitMQHost)), h =>
                        {
                            if (!string.IsNullOrEmpty(username))
                            {
                                h.Username(configuration.GetConnectionString(Constants.RabbitMQUsername));
                            }
                            if (!string.IsNullOrEmpty(password))
                            {
                                h.Password(configuration.GetConnectionString(Constants.RabbitMQPassword));
                            }

                        });
                    });
                    TaskUtil.Await(() => _bus.StartAsync());
                }
                return _bus;
            });

            services.AddTransient<ICommandBus, CommandBus>();

            // Add application services.
            services.AddTransient<IProductCategoryQueries, ProductCategoryQueries>();
            services.AddTransient<IDomainContext>(i => new DomainContext(i.GetService<IConfiguration>(), i.GetService<IBusControl>()));
            services.AddTransient<IDomainService>(i => new DomainService(i.GetService<IDomainContext>()));

            services.AddTransient<IDataAccessReadOnlyService>(i => new DataAccessReadOnlyService(i.GetService<ApplicationDbContext>()));
            services.AddTransient<IDataAccessWriteService>(i => new DataAccessWriteService(i.GetService<ApplicationDbContext>()));

            Domain.HandlerRegister.Register(services);
        }
    }
}
