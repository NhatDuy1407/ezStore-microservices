using System;
using System.Collections.Generic;

namespace Microservice.Core.Domain
{
    public class DomainEntity
    {
        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public bool Deleted { get; set; }

        private List<IEvent> events;
        public List<IEvent> Events => events;

        protected void AddDomainEvent(IEvent @event)
        {
            if (events == null)
            {
                events = new List<IEvent>();
            }
            events.Add(@event);
        }
    }
}