using System;
using MassTransit;
using MassTransit.RabbitMqTransport;
using MassTransit.Util;

namespace Microservice.Core.Service.Request
{
    public abstract class RequestService 
    {
        readonly string _rabbitMqHost;
        readonly string _serviceQueueName;

        protected RequestService(string rabbitMqHost, string serviceQueueName)
        {
            _rabbitMqHost = rabbitMqHost;
            _serviceQueueName = serviceQueueName;
        }

        IBusControl _busControl;

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
