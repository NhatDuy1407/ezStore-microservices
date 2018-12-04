using System;

namespace Microservice.Core.DomainService.Interfaces
{
    public interface IDomainEvent
    {
        Guid AggregateRootId { get; }
    }
}
