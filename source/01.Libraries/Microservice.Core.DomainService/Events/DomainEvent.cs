﻿using Microservice.Core.DomainService.Interfaces;
using System;

namespace Microservice.Core.DomainService.Events
{
    public class DomainEvent : IEvent
    {
        public DomainEvent()
        {
            AggregateRootId = Guid.NewGuid();
        }

        public Guid AggregateRootId { get; }
        public int Version { get; set; }
    }
}