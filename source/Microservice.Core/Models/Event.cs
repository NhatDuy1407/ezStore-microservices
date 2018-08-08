using System;
using Microservice.Core.Interfaces;

namespace Microservice.Core.Models
{
    public class Event : IEvent
    {
        public Event()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
    }
}