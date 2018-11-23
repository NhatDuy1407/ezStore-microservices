using Microservice.Core;
using Ws4vn.Core.Models;
using System;

namespace ezStore.DomainEvents.WareHouse
{
    [MessageBusRoute(EventRouteConstants.WareHouseService)]
    public class WareHouseUpdated : Event
    {
        public Guid Id { get; }

        public WareHouseUpdated(Guid id)
        {
            Id = id;
        }
    }
}
