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
                        x.Host(new Uri(configuration.GetConnectionString(Constants.RabbitMQHost)), h =>
                        {
                            //h.Username("guest");
                            //h.Password("guest");
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

            services.AddTransient<ICommandHandler<CreateProductCategoryCommand>, ProductCategoryCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateProductCategoryCommand>, ProductCategoryCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteProductCategoryCommand>, ProductCategoryCommandHandler>();
        }
    }
}
