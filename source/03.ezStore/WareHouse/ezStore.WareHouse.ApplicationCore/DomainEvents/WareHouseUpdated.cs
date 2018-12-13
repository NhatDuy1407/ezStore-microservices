using Microservices.ApplicationCore.Events;
using System;

namespace ezStore.WareHouse.ApplicationCore.DomainEvents
{
    public class WareHouseUpdated : DomainEvent
    {
        public Guid Id { get; }

        public WareHouseUpdated(Guid id)
        {
            Id = id;
        }
    }
}
