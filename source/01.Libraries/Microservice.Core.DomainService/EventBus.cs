using Microservice.Core.DomainService.Events;
using Microservice.Core.DomainService.Exceptions;
using Microservice.Core.DomainService.Interfaces;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Microservice.Core.DomainService
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

            if (handler == null)
                throw new EventHandlerNotFoundException();

            MethodInfo method = repositoryType.GetMethod("ExecuteAsync");
            MethodInfo genericMethod = method.MakeGenericMethod(elementType);

            return (Task)genericMethod.Invoke(handler, new[] { Convert.ChangeType(@event, elementType) });
        }
    }
}