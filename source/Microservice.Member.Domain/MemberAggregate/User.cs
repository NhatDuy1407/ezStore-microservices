using Microservice.Core.Domain;
using Microservice.Member.Domain.DomainEvents;

namespace Microservice.Member.Domain.MemberAggregate
{
    public class User : DomainEntity
    {
        public void NotifyUserLogin()
        {
            base.AddDomainEvent(new UserLoginedEvent());
        }
    }
}