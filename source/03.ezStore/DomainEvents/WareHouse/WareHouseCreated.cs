using Microservice.Core;
using Ws4vn.Core.Models;
using System;

namespace ezStore.DomainEvents.WareHouse
{
    [MessageBusRoute(EventRouteConstants.WareHouseService)]
    public class WareHouseCreated : Event
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
