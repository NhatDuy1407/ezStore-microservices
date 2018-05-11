using System.Collections.Generic;
using MassTransit;
using Microservice.Core.DataAccess.MongoDB;
using Microservice.Core.Interfaces;
using Microservice.Core.Models;

namespace Microservice.Member.Infrastructure
{
    public class MemberContext : MongoDbContext
    {
        private readonly IBusControl _busControl;

        public List<IEvent> Events { get; private set; }

        public MemberContext(string connectionString, string databaseName, bool isSsl, IBusControl busControl) : base(connectionString, databaseName, isSsl)
        {
            _busControl = busControl;
        }

        public void AddEvents(DomainEntity entity)
        {
            if (Events == null)
            {
                Events = new List<IEvent>();
            }
            Events.AddRange(entity.Events);
        }

        public void SaveChanges()
        {
            foreach (var @event in Events)
            {
                var eventData = new Event
                {
                    ModelName = @event.GetType().Name,
                    Data = @event.Data
                };

                _busControl.Publish(eventData);
            }
        }
    }
}