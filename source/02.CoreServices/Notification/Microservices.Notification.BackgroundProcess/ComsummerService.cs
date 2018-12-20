using MassTransit;
using MassTransit.RabbitMqTransport;
using Microservices.Notification.BackgroundProcess.Consumers;
using Ws4vn.Microservices.ApplicationCore.Events;
using Ws4vn.Microservices.Infrastructure.Events;
using Microsoft.Extensions.Configuration;
using System;

namespace Microservices.Notification.BackgroundProcess
{
    public class ComsummerService : ComsumerService
    {
        private readonly IConfiguration _configuration;

        public ComsummerService(IConfiguration configuration) : base(configuration, EventRouteConstants.NotificationService)
        {
            _configuration = configuration;
        }


        public override Action<IRabbitMqReceiveEndpointConfigurator> Configure()
        {
            return e =>
            {
                e.Consumer(() => new EmailNotificationConsumer(_configuration));
                e.Consumer(() => new PushNotificationConsumer(_configuration));
            };
        }
    }
}