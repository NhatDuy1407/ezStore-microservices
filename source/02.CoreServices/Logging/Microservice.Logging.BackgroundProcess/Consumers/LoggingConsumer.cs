using MassTransit;
using Microservice.Core.MessageQueue;
using Microservice.DomainEvents.Logging;
using Microservice.Logging.Infrastructure;
using System.Threading.Tasks;
using Microservice.DataAccess.Core.Interfaces;

namespace Microservice.Logging.BackgroundProcess.Consumers
{
    public class LoggingConsumer : BaseConsumer, IConsumer<WriteLogEvent>
    {
        private readonly IDataAccessWriteService writeService;

        public LoggingConsumer(IDataAccessWriteService writeService) : base()
        {
            this.writeService = writeService;
        }

        public Task Consume(ConsumeContext<WriteLogEvent> context)
        {
            writeService.Repository<LogData>().Insert(new LogData()
            {
                Date = context.Message.Date,
                Level = context.Message.Level,
                Thread = context.Message.Thread,
                Logger = context.Message.Logger,
                Message = context.Message.Message,
                Data = context.Message.Data,
                StackTrace = context.Message.StackTrace,
                ExceptionTypeName = context.Message.ExceptionTypeName
            });
            context.Respond(new { Status = true });

            return Task.CompletedTask;
        }
    }
}