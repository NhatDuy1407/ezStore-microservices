using System;
using RKSystem.Service.Core.Models;

namespace RKSystem.UserService.Models.Events
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
