using Microservice.Core.Interfaces;

namespace Microservice.Logging.BackgroundProcess.Consumers
{
    public class UserLoginedEvent : IEvent
    {
        public object Data { get; set; }
    }
}