using System;

namespace Ws4vn.Microservicess.ApplicationCore.Events
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
