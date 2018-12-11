using Microservice.Core.DomainService.Interfaces;
using System;

namespace Microservice.Core.DomainService.Events
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