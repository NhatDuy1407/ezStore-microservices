﻿using System;

namespace Ws4vn.Microservices.ApplicationCore.Interfaces
{
    public interface IEvent
    {
        Guid AggregateRootId { get; }
        int Version { get; set; }
    }
}
