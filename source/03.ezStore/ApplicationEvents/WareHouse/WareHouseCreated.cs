using Microservice.Core;
using Microservice.Core.DomainService.Events;
using System;

namespace ezStore.ApplicationEvents.WareHouse
{
    [MessageBusRoute(EventRouteConstants.WareHouseService)]
    public class WareHouseCreated : ApplicationEvent
    {
        public Guid Id { get; }
        public string Name { get; }

        public WareHouseCreated(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
