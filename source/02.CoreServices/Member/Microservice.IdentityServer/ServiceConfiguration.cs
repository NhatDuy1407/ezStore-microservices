using System;
using System.Linq;
using System.Reflection;
using MassTransit;
using MassTransit.Util;
using Microservice.Core;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.DataAccess.MongoDB;
using Microservice.Core.DomainService;
using Microservice.Core.DomainService.Interfaces;
using Microservice.Member.Domain;
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
            services.AddTransient<IDomainContext>(i => new DomainContext(i.GetService<IConfiguration>(), i.GetService<IBusControl>()));
            services.AddTransient<IDomainService>(i => new DomainService(i.GetService<IDomainContext>()));
            services.AddTransient(i => new MongoDbContext(configuration.GetConnectionString(Constants.MemberDbConnection), configuration.GetConnectionString(Constants.MemberDbName), false));
            services.AddTransient<IDataAccessWriteService>(i => new DataAccessWriteService(i.GetService<MongoDbContext>()));

            Member.Domain.HandlerRegister.Register(services);
        }
    }
}