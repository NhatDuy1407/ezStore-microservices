using System;
using Microservice.Core.Interfaces;

namespace Microservice.Core.Models
{
    public class Event : IEvent
    {
        public Event()
        {
            AggregateRootId = Guid.NewGuid();
        }

        public Guid AggregateRootId { get; }
    }
}