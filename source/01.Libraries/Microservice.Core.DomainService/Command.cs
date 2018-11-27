using System;
using Microservice.Core.DomainService.Interfaces;

namespace Microservice.Core.DomainService
{
    public abstract class Command : ICommand
    {
        public Guid CommandId { get; set; }

        protected Command()
        {
            CommandId = Guid.NewGuid();
        }

        public abstract bool Validate(IValidationContext validationContext);
    }
}