using Microservice.Core.Models;
using Microservice.SharedEvents.Member;

namespace Microservice.Member.Domain.MemberAggregate
{
    public class UserDomain : DomainEntity
    {
        public string Username { get; set; }

        public void Login()
        {
            base.ApplyChange(new UserLoginedEvent(Username));
        }
    }
}