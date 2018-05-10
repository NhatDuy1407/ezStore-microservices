using System;
using MassTransit;
using MassTransit.Util;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.Service;
using Microservice.IdentityServer.Application.Commands;
using Microservice.Member.Infrastructure;
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
                        x.Host(new Uri(configuration.GetConnectionString("RabbitMQHost")), h =>
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
            services.AddTransient(i => new MemberContext(configuration.GetConnectionString("MongoDefaultConnection"), configuration.GetConnectionString("MongoDefaultDatabaseName"), false, i.GetService<IBusControl>(), i.GetService<IConfiguration>()));
            services.AddTransient<IAttachEntityWriteService>(i => new WriteService(i.GetService<MemberContext>()));
            services.AddTransient<ICommandHandler<UpdateUserLoginCommand>, MemberCommandHandler>();
        }
    }
}