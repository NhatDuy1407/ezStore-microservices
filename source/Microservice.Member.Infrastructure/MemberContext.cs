using System;
using System.Collections.Generic;
using MassTransit;
using Microservice.Core.DataAccess.MongoDB;
using Microservice.Core.Interfaces;
using Microservice.Core.Models;
using Microsoft.Extensions.Configuration;

namespace Microservice.Member.Infrastructure
{
    public class MemberContext : MongoDbContext
    {
        private readonly IBusControl _busControl;
        private readonly IConfiguration _configuration;

        public List<IEvent> Events { get; private set; }

        public MemberContext(string connectionString, string databaseName, bool isSsl, IBusControl busControl, IConfiguration configuration) : base(connectionString, databaseName, isSsl)
        {
            _busControl = busControl;
            _configuration = configuration;
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
                var serviceAddress = GetServiceAddress("member_service");
                var client = _busControl.CreateRequestClient<Event, Object>(serviceAddress, TimeSpan.FromSeconds(500));
                client.Request(eventData);
            }
        }

        private Uri GetServiceAddress(string address)
        {
            var serviceAddress = new Uri($"{_configuration.GetConnectionString("RabbitMQHost")}/{address}");
            return serviceAddress;
        }
    }
}