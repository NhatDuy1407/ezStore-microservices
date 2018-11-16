using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microservice.Core.DomainService.Interfaces;
using Microservice.Core.DomainService.Models;
using Microservice.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Microservice.Core.DomainService
{
    public class DomainContext : IDomainContext
    {
        private readonly IBusControl _busControl;
        private readonly IConfiguration Configuration;

        public DomainContext(IConfiguration configuration, IBusControl busControl)
        {
            _busControl = busControl;
            Configuration = configuration;
        }

        public List<IEvent> Events { get; private set; }

        public void AddEvents(AggregateRoot entity)
        {
            if (Events == null)
            {
                Events = new List<IEvent>();
            }
            if (entity.Events != null)
            {
                foreach (var item in entity.Events)
                {
                    if (!Events.Any(i => i.AggregateRootId == item.AggregateRootId))
                    {
                        Events.Add(item);
                    }
                }
            }
        }

        public Task SaveChanges()
        {
            // everything was validated successfully

            // publish events
            foreach (var @event in Events)
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
            Events.Clear();
            return Task.CompletedTask;
        }
    }
}