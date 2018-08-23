using System;
using System.Collections.Generic;
using Microservice.Core.Interfaces;

namespace Microservice.Core.Models
{
    public class DomainEntity: ModelEntity<Guid>
    {
        public List<IEvent> Events { get; private set; }

        protected void ApplyEvent(IEvent @event)
        {
            if (Events == null)
            {
                Events = new List<IEvent>();
            }
            Events.Add(@event);
        }
    }
}