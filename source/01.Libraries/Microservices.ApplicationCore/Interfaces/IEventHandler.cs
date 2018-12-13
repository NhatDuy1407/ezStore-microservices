﻿using Ws4vn.Microservices.ApplicationCore.Events;
using System.Threading.Tasks;

namespace Ws4vn.Microservices.ApplicationCore.Interfaces
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task ExecuteAsync<TEvent>(TEvent @event);
    }
}