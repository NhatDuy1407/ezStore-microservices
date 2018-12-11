using System;
using System.Collections.Generic;

namespace Microservice.Core.DomainService.Interfaces
{
    public interface IEventStore
    {
        void SaveEvents(Guid aggregateId, IEnumerable<IEvent> events, int expectedVersion);
        List<IEvent> GetEventsForAggregate(Guid aggregateId);
    }
}
