using Ws4vn.Microservices.ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace Ws4vn.Microservices.ApplicationCore.Entities
{
    public class AggregateRoot : ModelGuidIdEntity
    {
        protected readonly IDataAccessService dataAccessService;

        public AggregateRoot(IDataAccessService dataAccessService)
        {
            this.dataAccessService = dataAccessService;
            Events = new List<IEvent>();
        }

        public List<IEvent> Events { get; private set; }

        protected void AddEvent(IEvent @event)
        {
            Events.Add(@event);
        }
    }
}