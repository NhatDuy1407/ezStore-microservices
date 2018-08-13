using System.Threading.Tasks;
using MassTransit;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Logging.Persistence.Model;
using Microservice.SharedEvents.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Microservice.Logging.BackgroundProcess.Consumers
{
    public class LoggingConsumer : BaseConsumer, IConsumer<WriteLogEvent>
    {
        private readonly IWriteService _writeService;

        public LoggingConsumer(IConfiguration configuration, IHostingEnvironment env, IWriteService writeService) : base(configuration, env)
        {
            _writeService = writeService;
        }

        public Task Consume(ConsumeContext<WriteLogEvent> context)
        {
            _writeService.Repository<LogData>().Insert(new LogData()
            {
                Date = context.Message.Date,
                Level = context.Message.Level,
                Thread = context.Message.Thread,
                Logger = context.Message.Logger,
                Message = context.Message.Message,
            });
            context.Respond(new { Status = true });

            return Task.CompletedTask;
        }
    }
}