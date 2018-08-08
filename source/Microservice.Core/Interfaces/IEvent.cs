using System;

namespace Microservice.Core.Interfaces
{
    public interface IEvent
    {
        Guid Id { get; }
    }
}