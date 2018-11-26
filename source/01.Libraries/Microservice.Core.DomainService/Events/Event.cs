using Microservice.Core.DomainService.Interfaces;
using System;

namespace Microservice.Core.DomainService.Events
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