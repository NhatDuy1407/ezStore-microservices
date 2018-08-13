using System;

namespace Microservice.Core.Interfaces
{
    public interface IEvent
    {
        Guid AggregateRootId { get; }
    }
}