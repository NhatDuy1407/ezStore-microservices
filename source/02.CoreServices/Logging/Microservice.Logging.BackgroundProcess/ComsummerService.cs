using MassTransit;
using MassTransit.RabbitMqTransport;
using Microservice.Core;
using Microservice.Core.DataAccess.MongoDB;
using Microservice.Core.MessageQueue.Request;
using Microservice.DomainEvents;
using Microservice.Logging.BackgroundProcess.Consumers;
using Microsoft.Extensions.Configuration;
using System;

namespace Microservice.Logging.BackgroundProcess
{
    public class ComsummerService : ComsumerService
    {
        private readonly IConfiguration _configuration;

        public ComsummerService(IConfiguration configuration) : base(configuration, EventRouteConstants.LoggingService)
        {
            _configuration = configuration;
        }


        public override Action<IRabbitMqReceiveEndpointConfigurator> Configure()
        {
            var dbConnection = new DataAccessWriteService(new MongoDbContext(_configuration.GetConnectionString(MicroserviceConstants.DefaultConnection), _configuration.GetConnectionString(MicroserviceConstants.DefaultDatabaseName), false));
            return e =>
            {
                e.Consumer(() => new LoggingConsumer(dbConnection));
            };
        }
    }
}