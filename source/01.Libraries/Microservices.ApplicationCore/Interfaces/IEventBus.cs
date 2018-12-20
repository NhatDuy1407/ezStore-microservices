using Ws4vn.Microservices.ApplicationCore.Events;
using System.Threading.Tasks;

namespace Ws4vn.Microservices.ApplicationCore.Interfaces
{
    public interface IEventBus
    {
        Task ExecuteAsync<TEvent>(TEvent @event) where TEvent : DomainEvent;
    }
}