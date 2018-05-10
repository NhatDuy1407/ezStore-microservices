using System;
using Microservice.Core.Interfaces;

namespace Microservice.Core.Models
{
    public class Command : ICommand
    {
        public Guid CommandId { get; set; }

        public Command()
        {
            CommandId = Guid.NewGuid();
        }
    }
}