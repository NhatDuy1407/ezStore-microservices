using Ws4vn.Microservices.ApplicationCore.Interfaces;
using System;

namespace Ws4vn.Microservices.ApplicationCore.Events
{
    public class IntegrationEvent : IEvent
    {
        public IntegrationEvent()
        {
            AggregateRootId = Guid.NewGuid();
        }

        public Guid AggregateRootId { get; }
        public int Version { get; set; }

        public bool Validate(IValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}