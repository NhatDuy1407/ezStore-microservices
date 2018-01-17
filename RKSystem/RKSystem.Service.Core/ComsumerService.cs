using System;
using MassTransit;
using MassTransit.RabbitMqTransport;
using MassTransit.Util;
using Topshelf;

namespace RKSystem.Service.Core
{
    //public abstract class ComsumerService : ServiceControl
    public abstract class ComsumerService : ServiceControl
    {
        protected abstract string _rabbitMqHost { get; }
        protected abstract string _serviceQueueName { get; }

        // readonly LogWriter _log = HostLogger.Get<RequestService>();

        IBusControl _busControl;

        public bool Start(HostControl hostControl)
        {
            //_log.Info("Creating bus...");

            _busControl = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                IRabbitMqHost host = x.Host(new Uri(_rabbitMqHost), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                x.ReceiveEndpoint(host, _serviceQueueName, Configure());
            });

            //_log.Info("Starting bus...");

            TaskUtil.Await(() => _busControl.StartAsync());

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            //_log.Info("Stopping bus...");

            _busControl?.Stop();

            return true;
        }

        public abstract Action<IRabbitMqReceiveEndpointConfigurator> Configure();
    }
}
