using Ws4vn.Microservices.ApplicationCore.Interfaces;
using System;

namespace Ws4vn.Microservices.ApplicationCore.Events
{
    public class ApplicationEvent : IEvent
    {
        public ApplicationEvent()
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