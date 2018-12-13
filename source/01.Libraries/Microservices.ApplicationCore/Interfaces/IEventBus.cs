using Microservices.ApplicationCore.Events;
using System.Threading.Tasks;

namespace Microservices.ApplicationCore.Interfaces
{
    public interface IEventBus
    {
        Task ExecuteAsync<TEvent>(TEvent @event) where TEvent : DomainEvent;
    }
}