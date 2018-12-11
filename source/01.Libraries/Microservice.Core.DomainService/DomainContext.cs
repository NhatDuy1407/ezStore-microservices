using MassTransit;
using Microservice.Core.DomainService.Events;
using Microservice.Core.DomainService.Interfaces;
using Microservice.Core.DomainService.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.Core.DomainService
{
    public class DomainContext : IDomainContext
    {
        private readonly IBusControl _busControl;
        private readonly IEventBus _eventBus;
        private readonly IConfiguration Configuration;

        public DomainContext(IConfiguration configuration, IBusControl busControl,  IEventBus eventBus)
        {
            _busControl = busControl;
            _eventBus = eventBus;
            Configuration = configuration;
        }

        public List<IEvent> ApplicationEvents { get; private set; }

        public List<IEvent> DomainEvents { get; private set; }

        public void AddEvents(AggregateRoot entity)
        {
            if (ApplicationEvents == null)
            {
                ApplicationEvents = new List<IEvent>();
            }
            if (entity.Events != null)
            {
                foreach (var item in entity.Events.OfType<ApplicationEvent>())
                {
                    if (!ApplicationEvents.Any(i => i.AggregateRootId == item.AggregateRootId))
                    {
                        ApplicationEvents.Add(item);
                    }
                }

                foreach (var item in entity.Events.OfType<DomainEvent>())
                {
                    if (!DomainEvents.Any(i => i.AggregateRootId == item.AggregateRootId))
                    {
                        DomainEvents.Add(item);
                    }
                }
            }
        }

        public Task SaveChanges()
        {
            foreach (var @event in DomainEvents)
            {
                _eventBus.ExecuteAsync(@event).Wait();
            }
            DomainEvents.Clear();

            // everything was validated successfully
            // publish events
            foreach (var @event in ApplicationEvents)
            {
                var attr = @event.GetType().GetCustomAttributes(true).FirstOrDefault(i => i is MessageBusRouteAttribute);
                if (attr != null)
                {
                    foreach (var key in (attr as MessageBusRouteAttribute).RouteKeys)
                    {
                        var sendEndPoint = _busControl.GetSendEndpoint(new System.Uri($"{Configuration.GetConnectionString(MicroserviceConstants.RabbitMQHost)}/{key}")).Result;
                        sendEndPoint.Send(@event, @event.GetType());
                    }
                }
                else
                {
                    _busControl.Publish(@event, @event.GetType());
                }
            }
            ApplicationEvents.Clear();
            return Task.CompletedTask;
        }
    }
}