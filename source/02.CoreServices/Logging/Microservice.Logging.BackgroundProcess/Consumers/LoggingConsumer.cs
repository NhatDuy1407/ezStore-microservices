using System.Threading.Tasks;
using MassTransit;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.MessageQueue;
using Microservice.Logging.Persistence.Model;
using Microservice.SharedEvents.Logging;
using Microsoft.Extensions.Configuration;

namespace Microservice.Logging.BackgroundProcess.Consumers
{
    public class LoggingConsumer : BaseConsumer, IConsumer<WriteLogEvent>
    {
        private readonly IDataAccessWriteService _writeService;

        public LoggingConsumer(IConfiguration configuration, IDataAccessWriteService writeService) : base()
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
                Data = context.Message.Data,
                StackTrace = context.Message.StackTrace
            });
            context.Respond(new { Status = true });

            return Task.CompletedTask;
        }
    }
}