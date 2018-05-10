using Microservice.Core.Interfaces;

namespace Microservice.Core.Models
{
    public class Event : IEvent
    {
        public string ModelName { get; set; }
        public object Data { get; set; }
    }
}