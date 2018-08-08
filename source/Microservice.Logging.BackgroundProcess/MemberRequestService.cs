using System;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Microservice.Core.DataAccess.MongoDB;
using Microservice.Core.Request;
using Microservice.Logging.BackgroundProcess.Consumers;
using Microsoft.Extensions.Configuration;

namespace Microservice.Logging.BackgroundProcess
{
    public class MemberRequestService : RequestService
    {
        private readonly IConfiguration _configuration;

        public MemberRequestService(IConfiguration configuration) : base(configuration.GetConnectionString("RabbitMQHost"), "member_service")
        {
            _configuration = configuration;
        }

        public override Action<IRabbitMqReceiveEndpointConfigurator> Configure()
        {
            return e =>
            {
                e.Consumer(() => new MemberConsumer(_configuration, new WriteService(new MongoDbContext(_configuration.GetConnectionString("DefaultConnection"), _configuration.GetConnectionString("DefaultDatabaseName"), false))));
            };
        }
    }
}