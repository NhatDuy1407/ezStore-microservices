using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.DomainService.Models;
using Microservice.Member.Infrastructure.Models;
using Microservice.SharedEvents.Logging;
using Microsoft.Extensions.Logging;

namespace Microservice.Member.Domain.MemberAggregate
{
    public class UserDomain : AggregateRoot
    {
        private readonly IDataAccessWriteService _writeService;

        public UserDomain(IDataAccessWriteService writeService)
        {
            _writeService = writeService;
        }

        public string Username { get; set; }

        public void Login()
        {
            var userLog = new UserLog() { Content = Username + " loged in." };
            _writeService.Repository<UserLog>().Insert(userLog);
            _writeService.SaveChanges();

            ApplyEvent(new WriteLogEvent()
            {
                Level = LogLevel.Information.ToString(),
                Logger = nameof(UserDomain),
                Thread = "",
                Message = $"Member {Username} logged in"
            });
        }
    }
}