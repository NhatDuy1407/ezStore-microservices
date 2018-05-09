using System;
using Microservice.Core.Service.Interfaces;

namespace Microservice.Core.Service.Models
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
