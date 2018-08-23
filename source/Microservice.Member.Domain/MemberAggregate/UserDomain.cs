using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.Models;
using Microservice.Member.Infrastructure.Models;
using Microservice.SharedEvents.Logging;
using Microservice.SharedEvents.Notification;
using Microsoft.Extensions.Logging;

namespace Microservice.Member.Domain.MemberAggregate
{
    public class UserDomain : DomainEntity
    {
        private readonly IWriteService _writeService;

        public UserDomain(IWriteService writeService)
        {
            _writeService = writeService;
        }

        public string Username { get; set; }

        public void Login()
        {
            var userLog = new UserLog() { Content = Username + " loged in." };
            _writeService.Repository<UserLog>().Insert(userLog);
            _writeService.SaveChanges();

            base.ApplyEvent(new WriteLogEvent()
            {
                Level = LogLevel.Information.ToString(),
                Logger = nameof(UserDomain),
                Thread = "",
                Message = $"Member {Username} logged in"
            });
        }
    }
}