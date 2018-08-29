using System;

namespace Microservice.Core
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
