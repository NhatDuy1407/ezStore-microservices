using System;
using Microservice.Core.Service.Models;

namespace Microservice.Service.UserService.Models.Events
{
    public class UserCreatedEvent : Event
    {
        public Guid UserId { get; set; }

        public UserCreatedEvent(Guid userId)
        {
            UserId = userId;
        }
    }
}
