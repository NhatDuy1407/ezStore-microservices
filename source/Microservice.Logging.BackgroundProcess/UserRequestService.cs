using System;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Microservice.Core.Service.Request;
using Microservice.Logging.BackgroundProcess.Consumers;
using Microservice.Logging.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Microservice.Logging.BackgroundProcess
{
    public class UserRequestService : RequestService
    {
        private readonly IConfiguration _configuration;

        public UserRequestService(IConfiguration configuration) : base(configuration.GetConnectionString("RabbitMQHost"), "member_service")
        {
            _configuration = configuration;
        }

        public override Action<IRabbitMqReceiveEndpointConfigurator> Configure()
        {
            return e =>
            {
                e.Consumer(() => new LoggingConsumer(_configuration, new WriteService(new LoggingContext(_configuration.GetConnectionString("DefaultConnection"), _configuration.GetConnectionString("DefaultDatabaseName"), false))));
            };
        }
    }
}