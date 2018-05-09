using System;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.Configuration;
using Microservice.Service.UserService.WriteSide.Consumers;
using Microservice.Core.Service.Request;

namespace Microservice.Service.UserService.WriteSide
{
    public class UserRequestService : RequestService
    {
        readonly IConfiguration _configuration;
        public UserRequestService(IConfiguration configuration) : base(configuration.GetConnectionString("RabbitMQHost"), "user_service")
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
