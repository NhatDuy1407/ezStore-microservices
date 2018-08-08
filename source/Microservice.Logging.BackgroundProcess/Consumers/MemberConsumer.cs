using System;
using System.Threading.Tasks;
using MassTransit;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Logging.Persistence.Model;
using Microservice.SharedEvents.Member;
using Microsoft.Extensions.Configuration;

namespace Microservice.Logging.BackgroundProcess.Consumers
{
    public class MemberConsumer : BaseConsumer, IConsumer<UserLoginedEvent>
    {
        private readonly IWriteService _writeService;

        public MemberConsumer(IConfiguration configuration, IWriteService writeService) : base(configuration)
        {
            _writeService = writeService;
        }

        public async Task Consume(ConsumeContext<UserLoginedEvent> context)
        {
            var username = context.Message.Username;
            _writeService.Repository<AuditLog>().Insert(new AuditLog()
            {
                Content = $"{username} log in at " + DateTime.Now.ToString("F")
            });
            context.Respond(new { Status = true });
        }
    }
}