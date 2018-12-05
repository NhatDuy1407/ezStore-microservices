using Microservice.Core.DomainService.Interfaces;
using System;

namespace Microservice.Core.DomainService.Events
{
    public class DomainEvent : IDomainEvent
    {
        public DomainEvent()
        {
            AggregateRootId = Guid.NewGuid();
        }

        public Guid AggregateRootId { get; }
    }
}