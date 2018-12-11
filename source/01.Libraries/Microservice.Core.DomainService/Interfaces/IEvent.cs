using System;

namespace Microservice.Core.DomainService.Interfaces
{
    public interface IEvent
    {
        Guid AggregateRootId { get; }
        int Version { get; set; }
    }
}
