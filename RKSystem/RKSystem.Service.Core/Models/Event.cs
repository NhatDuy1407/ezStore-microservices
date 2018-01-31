using System;
using RKSystem.Service.Core.Interfaces;

namespace RKSystem.Service.Core.Models
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
