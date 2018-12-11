using Microservice.Core;
using Microservice.Core.DomainService.Events;
using System;

namespace ezStore.ApplicationEvents.WareHouse
{
    [MessageBusRoute(EventRouteConstants.WareHouseService)]
    public class WareHouseUpdated : ApplicationEvent
    {
        public Guid Id { get; }

        public WareHouseUpdated(Guid id)
        {
            Id = id;
        }
    }
}
