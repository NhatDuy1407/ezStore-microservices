using Microservice.Core;
using Microservice.Core.Interfaces;
using Microservice.Core.Models;
using System;

namespace Microservice.SharedEvents.Logging
{
    [MessageBusRoute(EventRouteConstants.LoggingService)]
    public class WriteLogEvent : Event
    {
        public DateTime Date { get { return DateTime.Now; } }
        public string Level { get; set; }
        public string Thread { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
        public string StackTrace { get; set; }
    }
}
