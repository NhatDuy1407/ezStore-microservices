using Microservices.ApplicationCore.Interfaces;
using System;

namespace Microservices.ApplicationCore.Commands
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