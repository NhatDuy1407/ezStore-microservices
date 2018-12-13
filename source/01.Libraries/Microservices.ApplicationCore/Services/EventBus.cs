﻿using Ws4vn.Microservices.ApplicationCore.Events;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Ws4vn.Microservices.ApplicationCore.Services
{
    public class EventBus : IEventBus
    {
        private readonly IServiceProvider _provider;

        public EventBus(IServiceProvider provider)
        {
            _provider = provider;
        }

        public Task ExecuteAsync<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            if (@event == null)
                throw new ArgumentNullException("event");

            Type elementType = @event.GetType();
            Type repositoryType = typeof(IEventHandler<>).MakeGenericType(elementType);
            var handler = _provider.GetService(repositoryType);

            if (handler != null)
            {
                MethodInfo method = repositoryType.GetMethod("ExecuteAsync");
                MethodInfo genericMethod = method.MakeGenericMethod(elementType);

                return (Task)genericMethod.Invoke(handler, new[] { Convert.ChangeType(@event, elementType) });
            }

            return Task.CompletedTask;
        }
    }
}