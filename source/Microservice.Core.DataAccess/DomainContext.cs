using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MassTransit;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.Interfaces;
using Microservice.Core.Models;

namespace Microservice.Core.DataAccess
{
    public class DomainContext: IDomainContext
    {
        private readonly IBusControl _busControl;

        public DomainContext(IBusControl busControl)
        {
            _busControl = busControl;
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
            // everything was saved successfully

            // collect event

            // publish events
            foreach (var @event in Events)
            {
                _busControl.Publish(@event, @event.GetType());
            }
            Events.Clear();
        }
    }
}