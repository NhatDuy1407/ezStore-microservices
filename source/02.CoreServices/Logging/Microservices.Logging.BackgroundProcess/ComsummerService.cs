using MassTransit;
using MassTransit.RabbitMqTransport;
using Microservices.Logging.BackgroundProcess.Consumers;
using Ws4vn.Microservicess.ApplicationCore.Events;
using Ws4vn.Microservicess.ApplicationCore.SharedKernel;
using Ws4vn.Microservicess.Infrastructure.Events;
using Ws4vn.Microservicess.Infrastructure.MongoDB;
using Microsoft.Extensions.Configuration;
using System;

namespace Microservices.Logging.BackgroundProcess
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
            var dbConnection = new DataAccessWriteService(new MongoDbContext(_configuration.GetConnectionString(MicroservicesConstants.DefaultConnection), _configuration.GetConnectionString(MicroservicesConstants.DefaultDatabaseName), false));
            return e =>
            {
                e.Consumer(() => new LoggingConsumer(dbConnection));
            };
        }
    }
}