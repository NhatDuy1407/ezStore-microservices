using System;
using Microservice.Core.Interfaces;

namespace Microservice.Core
{
    public abstract class Command : ICommand
    {
        public Guid CommandId { get; set; }

        public Command()
        {
            CommandId = Guid.NewGuid();
        }

        public abstract bool Validate();
    }
}