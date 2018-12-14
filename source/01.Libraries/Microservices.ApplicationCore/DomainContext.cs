using MassTransit;
using Ws4vn.Microservicess.ApplicationCore.Entities;
using Ws4vn.Microservicess.ApplicationCore.Events;
using Ws4vn.Microservicess.ApplicationCore.Interfaces;
using Ws4vn.Microservicess.ApplicationCore.SharedKernel;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Ws4vn.Microservices.ApplicationCore
{
    public class DomainContext : IDomainContext
    {
        private readonly IBusControl _busControl;
        private readonly IEventBus _eventBus;
        private readonly IConfiguration Configuration;

        public DomainContext(IConfiguration configuration, IBusControl busControl, IEventBus eventBus)
        {
            _busControl = busControl;
            _eventBus = eventBus;
            Configuration = configuration;
        }

        public void SaveEvents(AggregateRoot entity)
        {
            foreach (var @event in entity.Events.OfType<DomainEvent>())
            {
                // excute event & update ReadModel
                _eventBus.ExecuteAsync(@event);
            }

            foreach (var @event in entity.Events.OfType<ApplicationEvent>())
            {
                var attr = @event.GetType().GetCustomAttributes(true).FirstOrDefault(i => i is MessageBusRouteAttribute);
                if (attr != null)
                {
                    foreach (var key in (attr as MessageBusRouteAttribute).RouteKeys)
                    {
                        var sendEndPoint = _busControl.GetSendEndpoint(new System.Uri($"{Configuration.GetConnectionString(MicroservicesConstants.RabbitMQHost)}/{key}")).Result;
                        sendEndPoint.Send(@event, @event.GetType());
                    }
                }
                else
                {
                    _busControl.Publish(@event, @event.GetType());
                }
            }
        }
    }
}