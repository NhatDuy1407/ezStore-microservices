using System;

namespace Ws4vn.Microservices.ApplicationCore.Events
{
    public class MessageBusRouteAttribute : Attribute
    {
        public string[] RouteKeys { get; set; }

        public MessageBusRouteAttribute(params string[] keys)
        {
            RouteKeys = keys;
        }
    }
}
