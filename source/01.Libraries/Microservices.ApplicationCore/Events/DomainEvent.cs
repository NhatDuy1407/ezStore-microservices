using Ws4vn.Microservicess.ApplicationCore.Interfaces;
using System;

namespace Ws4vn.Microservicess.ApplicationCore.Events
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