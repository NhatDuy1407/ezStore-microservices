using System;
using MassTransit;
using MassTransit.RabbitMqTransport;
using RKSystem.Service.Core.Request;
using RKSystem.UserService.WriteSide.Consumers;

namespace RKSystem.UserService.WriteSide
{
    public class UserRequestService : RequestService
    {
        public UserRequestService(string host, string service) : base(host, service)
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
