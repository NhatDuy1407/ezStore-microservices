using Microservice.Core.Interfaces;
using Microservice.Core.Models;

namespace Microservice.SharedEvents.Member
{
    public class UserLoginedEvent : Event, IEvent
    {
        public UserLoginedEvent(string userName)
        {
            this.Username = userName;
        }

        public string Username { get; set; }
    }
}
