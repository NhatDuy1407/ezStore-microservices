using System;
using System.Collections.Generic;
using Microservice.Core.Interfaces;

namespace Microservice.Core.Models
{
    public class DomainEntity: ModelEntity
    {
        public List<IEvent> Events { get; private set; }

        protected void ApplyChange(IEvent @event)
        {
            if (Events == null)
            {
                Events = new List<IEvent>();
            }
            Events.Add(@event);
        }
    }
}