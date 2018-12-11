using MassTransit;
using Microservice.Core.DomainService.Exceptions;
using Microservice.Core.DomainService.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microservice.Core.DomainService
{
    public class EventStore : IEventStore
    {
        private readonly IBusControl _publisher;
        private readonly IConfiguration Configuration;

        private struct EventDescriptor
        {
            public readonly IEvent EventData;
            public readonly Guid Id;
            public readonly int Version;

            public EventDescriptor(Guid id, IEvent eventData, int version)
            {
                EventData = eventData;
                Version = version;
                Id = id;
            }
        }

        public EventStore(IConfiguration configuration, IBusControl publisher)
        {
            _publisher = publisher;
            Configuration = configuration;
        }

        private readonly Dictionary<Guid, List<EventDescriptor>> _current = new Dictionary<Guid, List<EventDescriptor>>();

        public void SaveEvents(Guid aggregateId, IEnumerable<IEvent> events, int expectedVersion)
        {
            List<EventDescriptor> eventDescriptors;

            // try to get event descriptors list for given aggregate id
            // otherwise -> create empty dictionary
            if (!_current.TryGetValue(aggregateId, out eventDescriptors))
            {
                eventDescriptors = new List<EventDescriptor>();
                _current.Add(aggregateId, eventDescriptors);
            }
            // check whether latest event version matches current aggregate version
            // otherwise -> throw exception
            else if (eventDescriptors[eventDescriptors.Count - 1].Version != expectedVersion && expectedVersion != -1)
            {
                throw new ConcurrencyException();
            }
            var i = expectedVersion;

            // iterate through current aggregate events increasing version with each processed event
            foreach (var @event in events)
            {
                i++;
                @event.Version = i;

                // push event to the event descriptors list for current aggregate
                eventDescriptors.Add(new EventDescriptor(aggregateId, @event, i));

                // publish current event to the bus for further processing by subscribers

                var attr = @event.GetType().GetCustomAttributes(true).FirstOrDefault(j => j is MessageBusRouteAttribute);
                if (attr != null)
                {
                    foreach (var key in (attr as MessageBusRouteAttribute).RouteKeys)
                    {
                        var sendEndPoint = _publisher.GetSendEndpoint(new System.Uri($"{Configuration.GetConnectionString(MicroserviceConstants.RabbitMQHost)}/{key}")).Result;
                        sendEndPoint.Send(@event, @event.GetType());
                    }
                }
                else
                {
                    _publisher.Publish(@event, @event.GetType());
                }
            }
        }

        // collect all processed events for given aggregate and return them as a list
        // used to build up an aggregate from its history (Domain.LoadsFromHistory)
        public List<IEvent> GetEventsForAggregate(Guid aggregateId)
        {
            List<EventDescriptor> eventDescriptors;

            if (!_current.TryGetValue(aggregateId, out eventDescriptors))
            {
                throw new AggregateNotFoundException();
            }

            return eventDescriptors.Select(desc => desc.EventData).ToList();
        }
    }
}
