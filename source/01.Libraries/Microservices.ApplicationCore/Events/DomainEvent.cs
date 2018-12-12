using Microservices.ApplicationCore.Interfaces;
using System;

namespace Microservices.ApplicationCore.Events
{
    public class DomainEvent : IEvent
    {
        public DomainEvent()
        {
            AggregateRootId = Guid.NewGuid();
        }

        public Guid AggregateRootId { get; }
        public int Version { get; set; }
    }
}