using Microservice.Core.Models;
using Microservice.SharedEvents.Logging;
using Microsoft.Extensions.Logging;

namespace Microservice.Member.Domain.MemberAggregate
{
    public class UserDomain : DomainEntity
    {
        public string Username { get; set; }

        public void Login()
        {
            base.ApplyChange(new WriteLogEvent()
            {
                Level = LogLevel.Information.ToString(),
                Logger = nameof(UserDomain),
                Thread = "",
                Message = $"Member {Username} logged in"
            });
        }
    }
}