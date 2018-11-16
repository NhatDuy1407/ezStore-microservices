using System;
using System.Collections.Generic;
using Microservice.Core.Interfaces;
using Microservice.Core.Models;

namespace Microservice.Core.DomainService.Models
{
    public class AggregateRoot : ModelGuidIdEntity
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