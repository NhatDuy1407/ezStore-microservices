using System;
using MassTransit;
using MassTransit.Util;
using Microservice.Core;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.DataAccess.MongoDB;
using Microservice.Core.DomainService;
using Microservice.Core.DomainService.Interfaces;
using Microservice.Member.Domain.Application.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.IdentityServer
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

            // Add application services.
            services.AddTransient<IDomainContext>(i => new DomainContext(i.GetService<IConfiguration>(), i.GetService<IBusControl>()));
            services.AddTransient<IDomainService>(i => new DomainService(i.GetService<IDomainContext>()));
            services.AddTransient(i => new MongoDbContext(configuration.GetConnectionString(Constants.MemberDbConnection), configuration.GetConnectionString(Constants.MemberDbName), false));
            services.AddTransient<IWriteService>(i => new WriteService(i.GetService<MongoDbContext>()));
            services.AddTransient<ICommandHandler<UpdateUserLoginCommand>, MemberCommandHandler>();
        }
    }
}