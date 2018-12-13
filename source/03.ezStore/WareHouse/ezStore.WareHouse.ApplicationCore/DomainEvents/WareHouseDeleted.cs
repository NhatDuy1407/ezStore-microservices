using Ws4vn.Microservices.ApplicationCore.Events;
using System;

namespace ezStore.WareHouse.ApplicationCore.DomainEvents
{
    public class WareHouseDeleted : DomainEvent
    {
        public Guid Id { get; }

        public WareHouseDeleted(Guid id)
        {
            Id = id;
        }
    }
}
