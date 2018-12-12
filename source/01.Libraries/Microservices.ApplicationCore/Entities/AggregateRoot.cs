using Microservices.ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace Microservices.ApplicationCore.Entities
{
    public class AggregateRoot : ModelGuidIdEntity
    {
        protected readonly IDataAccessService dataAccessService;

        public AggregateRoot(IDataAccessService dataAccessService)
        {
            this.dataAccessService = dataAccessService;
        }

        public List<IEvent> Events { get; private set; }

        protected void AddEvent(IEvent @event)
        {
            if (Events == null)
            {
                Events = new List<IEvent>();
            }
            Events.Add(@event);
        }
    }
}