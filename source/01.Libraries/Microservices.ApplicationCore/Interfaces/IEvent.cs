using System;

namespace Microservices.ApplicationCore.Interfaces
{
    public interface IEvent
    {
        Guid AggregateRootId { get; }
        int Version { get; set; }
    }
}
