using Microservice.Core;
using Microservice.Core.DomainService.Events;
using System;

namespace ezStore.DomainEvents.WareHouse
{
    [MessageBusRoute(EventRouteConstants.WareHouseService)]
    public class WareHouseUpdated : DomainEvent
    {
        public Guid Id { get; }

        public WareHouseUpdated(Guid id)
        {
            Id = id;
        }
    }
}
