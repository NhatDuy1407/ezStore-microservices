using System;
using RKSystem.Service.Core.Interfaces;

namespace RKSystem.Service.Core.Models
{
    public class Command : ICommand
    {
        protected Guid CommandId { get; set; }
        public Command()
        {
            CommandId = Guid.NewGuid();
        }
    }
}
