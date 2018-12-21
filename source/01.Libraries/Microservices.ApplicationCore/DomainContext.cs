using System.Linq;
using Ws4vn.Microservices.ApplicationCore.Entities;
using Ws4vn.Microservices.ApplicationCore.Events;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace Ws4vn.Microservices.ApplicationCore
{
    public class DomainContext : IDomainContext
    {
        private readonly IMessageBus _messageBus;
        private readonly IEventBus _eventBus;

        public DomainContext(IMessageBus messageBus, IEventBus eventBus)
        {
            _messageBus = messageBus;
            _eventBus = eventBus;
        }

        public void SaveEvents(AggregateRoot entity)
        {
            foreach (var @event in entity.Events.OfType<DomainEvent>())
            {
                // excute event & update ReadModel
                _eventBus.ExecuteAsync(@event);
            }

            foreach (var @event in entity.Events.OfType<IntegrationEvent>())
            {
                var attr = @event.GetType().GetCustomAttributes(true).FirstOrDefault(i => i is MessageBusRouteAttribute);
                if (attr != null)
                {
                    foreach (var key in (attr as MessageBusRouteAttribute).RouteKeys)
                    {
                        _messageBus.Send(key, @event, @event.GetType());
                    }
                }
                else
                {
                    _messageBus.Publish(@event, @event.GetType());
                }
            }
        }
    }
}