using Microservice.Core.DomainService.Interfaces;
using Microservice.Core.Models;
using System.Collections.Generic;

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