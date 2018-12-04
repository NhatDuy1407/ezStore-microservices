using Microservice.Core.DomainService.Interfaces;
using Microservice.Core.Models;
using Microservice.DataAccess.Core.Interfaces;
using System.Collections.Generic;

namespace Microservice.Core.DomainService.Models
{
    public class AggregateRoot : ModelGuidIdEntity
    {
        protected readonly IDataAccessService dataAccessService;

        public AggregateRoot(IDataAccessService dataAccessService)
        {
            this.dataAccessService = dataAccessService;
        }

        public List<IDomainEvent> Events { get; private set; }

        protected void ApplyEvent(IDomainEvent @event)
        {
            if (Events == null)
            {
                Events = new List<IDomainEvent>();
            }
            Events.Add(@event);
        }
    }
}