using System.Collections.Generic;
using System.Linq;
using MassTransit;
using Microservice.Core.DomainService.Interfaces;
using Microservice.Core.Interfaces;
using Microservice.Core.Models;
using Microsoft.Extensions.Configuration;

namespace Microservice.Core.DomainService
{
    public class DomainContext : IDomainContext
    {
        private readonly IBusControl _busControl;
        private IConfiguration Configuration;

        public DomainContext(IConfiguration configuration, IBusControl busControl)
        {
            _busControl = busControl;
            Configuration = configuration;
        }

        public List<IEvent> Events { get; private set; }

        public void AddEvents(DomainEntity entity)
        {
            if (Events == null)
            {
                Events = new List<IEvent>();
            }
            if (entity.Events != null)
            {
                foreach (var item in entity.Events)
                {
                    if (!Events.Any(i => i.Id == item.Id))
                    {
                        Events.Add(item);
                    }
                }
            }
        }

        public void SaveChanges()
        {
            // everything was validated successfully

            // publish events
            foreach (var @event in Events)
            {
                var attr = @event.GetType().GetCustomAttributes(true).Where(i => i is MessageBusRouteAttribute).FirstOrDefault();
                if (attr != null)
                {
                    foreach (var item in (attr as MessageBusRouteAttribute).RouteKeys)
                    {
                        var sendEndPoint = _busControl.GetSendEndpoint(new System.Uri(Configuration.GetConnectionString(Constants.RabbitMQHost) + "/" + item)).Result;
                        sendEndPoint.Send(@event, @event.GetType());
                    }
                }
                else
                {
                    _busControl.Publish(@event, @event.GetType());
                }
            }
            Events.Clear();
        }
    }
}