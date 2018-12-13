using System;
using MassTransit;
using MassTransit.RabbitMqTransport;
using MassTransit.Util;
using Ws4vn.Microservices.ApplicationCore.SharedKernel;
using Microsoft.Extensions.Configuration;

namespace Ws4vn.Microservices.Infrastructure.Events
{
    public abstract class ComsumerService
    {
        private readonly string _serviceQueueName;
        private readonly IConfiguration _configuration;

        protected ComsumerService(IConfiguration configuration, string serviceQueueName)
        {
            _serviceQueueName = serviceQueueName;
            _configuration = configuration;
        }

        private IBusControl _busControl;

        public bool Start()
        {
            _busControl = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                var username = _configuration.GetConnectionString(MicroserviceConstants.RabbitMQUsername);
                var password = _configuration.GetConnectionString(MicroserviceConstants.RabbitMQPassword);
                IRabbitMqHost host = x.Host(new Uri(_configuration.GetConnectionString(MicroserviceConstants.RabbitMQHost)), h =>
                {
                    if (!string.IsNullOrEmpty(username))
                    {
                        h.Username(_configuration.GetConnectionString(MicroserviceConstants.RabbitMQUsername));
                    }
                    if (!string.IsNullOrEmpty(password))
                    {
                        h.Password(_configuration.GetConnectionString(MicroserviceConstants.RabbitMQPassword));
                    }
                });

                x.ReceiveEndpoint(host, _serviceQueueName, Configure());
            });

            TaskUtil.Await(() => _busControl.StartAsync());

            return true;
        }

        public bool Stop()
        {
            _busControl?.Stop();

            return true;
        }

        public abstract Action<IRabbitMqReceiveEndpointConfigurator> Configure();
    }
}