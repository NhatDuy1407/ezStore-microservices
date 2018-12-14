using System;

namespace Ws4vn.Microservicess.ApplicationCore.Interfaces
{
    public interface IEvent
    {
        Guid AggregateRootId { get; }
        int Version { get; set; }
    }
}
