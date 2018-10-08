using System;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Microservice.Core;
using Microservice.Core.DataAccess.MongoDB;
using Microservice.Core.MessageQueue.Request;
using Microservice.Logging.BackgroundProcess.Consumers;
using Microservice.SharedEvents;
using Microsoft.Extensions.Configuration;

namespace Microservice.Logging.BackgroundProcess
{
    public class ComsummerService : ComsumerService
    {
        private readonly IConfiguration _configuration;

        public ComsummerService(IConfiguration configuration) : base(configuration.GetConnectionString(Constants.RabbitMQHost), EventRouteConstants.LoggingService)
        {
            _configuration = configuration;
        }


        public override Action<IRabbitMqReceiveEndpointConfigurator> Configure()
        {
            var dbConnection = new DataAccessWriteService(new MongoDbContext(_configuration.GetConnectionString(Constants.DefaultConnection), _configuration.GetConnectionString(Constants.DefaultDatabaseName), false));
            return e =>
            {
                e.Consumer(() => new LoggingConsumer(_configuration, dbConnection));
            };
        }
    }
}