using Microservice.Core;
using Microservice.Core.DomainService.Events;
using Microservice.Core.Models;
using System;

namespace ezStore.ApplicationEvents.WareHouse
{
    [MessageBusRoute(EventRouteConstants.WareHouseService)]
    public class WareHouseDeleted : ApplicationEvent
    {
        public Guid Id { get; }

        public WareHouseDeleted(Guid id)
        {
            Id = id;
        }
    }
}
