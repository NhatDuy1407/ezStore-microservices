using System;
using System.IO;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using RKSystem.Service.Core;

namespace RKSystem.UserService.WriteSide
{
    class UserRequestService : ComsumerService
    {
        public UserRequestService()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            _rabbitMqHost = configuration["ConnectionStrings:RabbitMQHost"];
            _serviceQueueName = configuration["ConnectionStrings:ServiceAddress"];
        }

        protected override string _rabbitMqHost { get; set; }

        protected override string _serviceQueueName { get; set; }

        public override Action<IRabbitMqReceiveEndpointConfigurator> Configure()
        {
            return e =>
            {
                e.Consumer<UserRequestConsumer>();
            };
        }
    }
}
