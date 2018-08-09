using System;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Microservice.Core.DataAccess.MongoDB;
using Microservice.Core.MessageQueue.Request;
using Microservice.Logging.BackgroundProcess.Consumers;
using Microsoft.Extensions.Configuration;

namespace Microservice.Logging.BackgroundProcess
{
    public class ComsummerService : ComsumerService
    {
        private readonly IConfiguration _configuration;

        public ComsummerService(IConfiguration configuration) : base(configuration.GetConnectionString("RabbitMQHost"), "logging_service")
        {
            _configuration = configuration;
        }

        public override Action<IRabbitMqReceiveEndpointConfigurator> Configure()
        {
            var dbConnection = new WriteService(new MongoDbContext(_configuration.GetConnectionString("DefaultConnection"), _configuration.GetConnectionString("DefaultDatabaseName"), false));
            return e =>
            {
                e.Consumer(() => new LoggingConsumer(_configuration, dbConnection));
            };
        }
    }
}