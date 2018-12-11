using Microservice.Core.DomainService.Events;
using System;

namespace ezStore.WareHouse.ApplicationCore.DomainEvents
{
    public class WareHouseCreated : DomainEvent
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
