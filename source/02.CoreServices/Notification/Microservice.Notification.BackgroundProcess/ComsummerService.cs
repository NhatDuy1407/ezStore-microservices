using MassTransit;
using MassTransit.RabbitMqTransport;
using Microservice.Notification.BackgroundProcess.Consumers;
using Microservices.ApplicationCore.Events;
using Microservices.Infrastructure.Events;
using Microsoft.Extensions.Configuration;
using System;

namespace Microservice.Notification.BackgroundProcess
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