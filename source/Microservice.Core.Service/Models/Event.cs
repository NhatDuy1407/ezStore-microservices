using System;
using Microservice.Core.Service.Interfaces;

namespace Microservice.Core.Service.Models
{
    public class Event : ICommand
    {
        public Guid EventId { get; }
        public Event()
        {
            EventId = Guid.NewGuid();
        }
    }
}
