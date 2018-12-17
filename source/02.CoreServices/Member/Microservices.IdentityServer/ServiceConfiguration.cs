using MassTransit;
using MassTransit.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Ws4vn.Microservicess.ApplicationCore.Interfaces;
using Ws4vn.Microservicess.ApplicationCore.SharedKernel;
using Ws4vn.Microservicess.Infrastructure.MongoDB;

namespace Microservices.IdentityServer
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
            services.AddScoped(i => new MongoDbContext(configuration.GetConnectionString(MicroservicesConstants.MemberDbConnection), configuration.GetConnectionString(MicroservicesConstants.MemberDbName), false));
            services.AddTransient<IDataAccessService>(i => new DataAccessWriteService(i.GetService<MongoDbContext>()));
            services.AddTransient<IDataAccessWriteService>(i => new DataAccessWriteService(i.GetService<MongoDbContext>()));

            Member.ApplicationCore.HandlerRegister.Register(services);
        }
    }
}