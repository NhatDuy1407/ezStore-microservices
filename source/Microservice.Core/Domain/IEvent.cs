namespace Microservice.Core.Domain
{
    public interface IEvent
    {
        object Data { get; set; }
    }
}