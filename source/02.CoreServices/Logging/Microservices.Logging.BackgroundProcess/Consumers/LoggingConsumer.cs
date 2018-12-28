﻿using MassTransit;
using Microservices.Logging.ApplicationCore.Entities;
using System.Threading.Tasks;
using Ws4vn.Microservices.ApplicationCore.Events;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using Ws4vn.Microservices.Infrastructure.RabbitMQ;

namespace Microservices.Logging.BackgroundProcess.Consumers
{
    public class LoggingConsumer : BaseConsumer, IConsumer<WriteLogEvent>
    {
        private readonly IDataAccessWriteService _writeService;

        public LoggingConsumer(IDataAccessWriteService writeService) : base()
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
                StackTrace = context.Message.StackTrace,
                ExceptionTypeName = context.Message.ExceptionTypeName
            });
            context.Respond(new { Status = true });

            return Task.CompletedTask;
        }
    }
}