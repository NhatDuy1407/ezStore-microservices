using System;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.Configuration;
using RKSystem.Service.Core.Constants;
using RKSystem.Service.Core.Request;
using RKSystem.UserService.WriteSide.Consumers;

namespace RKSystem.UserService.WriteSide
{
    public class UserRequestService : RequestService
    {
        IConfiguration _configuration;
        public UserRequestService(IConfiguration configuration) : base(configuration.GetConnectionString("RabbitMQHost"), ServiceAddresses.UserServiceAddress)
        {
            _configuration = configuration;
        }

        public override Action<IRabbitMqReceiveEndpointConfigurator> Configure()
        {
            return e =>
            {
                e.Consumer(() => new AddUserConsumer(_configuration, new UserService(_configuration)));
            };
        }
    }
}
