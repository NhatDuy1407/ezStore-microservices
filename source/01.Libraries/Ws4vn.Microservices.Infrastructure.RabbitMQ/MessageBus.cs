using MassTransit;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using Ws4vn.Microservices.ApplicationCore.SharedKernel;

namespace Ws4vn.Microservices.Infrastructure.RabbitMQ
{
    public class MessageBus : IMessageBus
    {
        private readonly IBusControl _busControl;
        private readonly IConfiguration Configuration;

        public MessageBus(IConfiguration configuration, IBusControl busControl)
        {
            _busControl = busControl;
            Configuration = configuration;
        }

        public Task Send<T>(string channel, T message, Type messageType, CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            var sendEndPoint = _busControl.GetSendEndpoint(new Uri($"{Configuration.GetConnectionString(MicroservicesConstants.MessageBusHost)}/{channel}")).Result;
            sendEndPoint.Send(message, messageType);

            return Task.CompletedTask;
        }

        public Task Send<T>(string channel, T message, CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            var sendEndPoint = _busControl.GetSendEndpoint(new Uri($"{Configuration.GetConnectionString(MicroservicesConstants.MessageBusHost)}/{channel}")).Result;
            sendEndPoint.Send(message);

            return Task.CompletedTask;
        }

        public Task Publish<T>(T message, Type messageType, CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            _busControl.Publish(message, messageType);
            return Task.CompletedTask;
        }
    }
}
