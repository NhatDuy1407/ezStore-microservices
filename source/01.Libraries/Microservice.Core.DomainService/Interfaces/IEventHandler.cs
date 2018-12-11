using System.Threading.Tasks;

namespace Microservice.Core.DomainService.Interfaces
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task ExecuteAsync(TEvent @event);
    }
}