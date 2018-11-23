using Microservice.Core;
using Ws4vn.Core.Models;
using System;

namespace ezStore.DomainEvents.WareHouse
{
    [MessageBusRoute(EventRouteConstants.WareHouseService)]
    public class WareHouseDeleted : Event
    {
        public Guid Id { get; }

        public WareHouseDeleted(Guid id)
        {
            Id = id;
        }
    }
}
