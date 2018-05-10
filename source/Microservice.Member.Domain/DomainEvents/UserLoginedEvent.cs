using Microservice.Core.Domain;

namespace Microservice.Member.Domain.DomainEvents
{
    public class UserLoginedEvent : IEvent
    {
        public UserLoginedEvent(string userName)
        {
            Data = userName;
        }

        public object Data { get; set; }
    }
}