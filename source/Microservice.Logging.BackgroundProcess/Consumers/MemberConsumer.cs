using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MassTransit;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.Models;
using Microservice.Logging.Domain.AuditLoggingAggregate;
using Microsoft.Extensions.Configuration;

namespace Microservice.Logging.BackgroundProcess.Consumers
{
    public class MemberConsumer : BaseConsumer, IConsumer<Event>
    {
        private readonly IWriteService _writeService;
        private readonly Dictionary<string, Action<object>> _handlers = new Dictionary<string, Action<object>>();

        public MemberConsumer(IConfiguration configuration, IWriteService writeService) : base(configuration)
        {
            _writeService = writeService;
            _handlers.Add(typeof(UserLoginedEvent).Name, HandlerUserLoginedEvent);
        }

        public async Task Consume(ConsumeContext<Event> context)
        {
            _handlers[context.Message.ModelName](context.Message.Data);
            context.Respond(new { Status = true });
        }

        private void HandlerUserLoginedEvent(object data)
        {
            var username = data;
            _writeService.Repository<AuditLogging>().Insert(new AuditLogging()
            {
                Content = $"{username} log in at " + DateTime.Now.ToString("F")
            });
        }
    }
}