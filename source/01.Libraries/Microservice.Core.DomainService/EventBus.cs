using Microservice.Core.DomainService.Exceptions;
using Microservice.Core.DomainService.Interfaces;
using System;
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

        public Task ExecuteAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            if (@event == null)
                throw new ArgumentNullException("event");

            var handler = _provider.GetService(typeof(IEventHandler<TEvent>));

            if (handler == null)
                throw new EventHandlerNotFoundException();

            return (handler as IEventHandler<TEvent>).ExecuteAsync(@event);
        }
    }
}