using System;
using System.Threading.Tasks;
using MassTransit;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Logging.Domain.AuditLoggingAggregate;
using Microsoft.Extensions.Configuration;

namespace Microservice.Logging.BackgroundProcess.Consumers
{
    public class LoggingConsumer : BaseConsumer, IConsumer<UserLoginedEvent>
    {
        private readonly IWriteService _writeService;

        public LoggingConsumer(IConfiguration configuration, IWriteService writeService) : base(configuration)
        {
            _writeService = writeService;
        }

        public async Task Consume(ConsumeContext<UserLoginedEvent> context)
        {
            var username = context.Message.Data;
            _writeService.Repository<AuditLogging>().Insert(new AuditLogging()
            {
                Content = $"{username} log in at " + DateTime.Now.ToString("F")
            });
            context.Respond(new { Status = true });
        }
    }
}