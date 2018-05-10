using Microservice.Core.Models;
using Microservice.Member.Domain.DomainEvents;

namespace Microservice.Member.Domain.MemberAggregate
{
    public class User : DomainEntity
    {
        public string UserName { get; set; }

        public void NotifyUserLogin()
        {
            base.AddDomainEvent(new UserLoginedEvent(UserName));
        }
    }
}