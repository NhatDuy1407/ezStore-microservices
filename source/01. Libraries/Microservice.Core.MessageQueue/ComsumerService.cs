using System;
using MassTransit;
using MassTransit.RabbitMqTransport;
using MassTransit.Util;

namespace Microservice.Core.MessageQueue.Request
{
    public abstract class ComsumerService
    {
        private readonly string _rabbitMqHost;
        private readonly string _serviceQueueName;

        protected ComsumerService(string rabbitMqHost, string serviceQueueName)
        {
            _rabbitMqHost = rabbitMqHost;
            _serviceQueueName = serviceQueueName;
        }

        private IBusControl _busControl;

        public bool Start()
        {
            _busControl = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                IRabbitMqHost host = x.Host(new Uri(_rabbitMqHost), h =>
                {
                    //h.Username("guest");
                    //h.Password("guest");
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