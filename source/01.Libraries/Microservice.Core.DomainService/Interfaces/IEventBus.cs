using Microservice.Core.DomainService.Events;
using System.Threading.Tasks;

namespace Microservice.Core.DomainService.Interfaces
{
    public interface IEventBus
    {
        Task ExecuteAsync<TEvent>(TEvent @event) where TEvent : DomainEvent;
    }
}