using System;
using MassTransit;
using MassTransit.RabbitMqTransport;

namespace RKSystem.UserService.WriteSide
{
    public class RequestService : Service.Core.Request.RequestService
    {
        public RequestService() : base("rabbitmq://192.168.0.101", "user_service")
        {
        }

        public override Action<IRabbitMqReceiveEndpointConfigurator> Configure()
        {
            return e =>
            {
                e.Consumer<AddUserConsumer>();
            };
        }
    }
}
