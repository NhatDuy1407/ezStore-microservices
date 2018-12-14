using Ws4vn.Microservicess.ApplicationCore.Events;
using System.Threading.Tasks;

namespace Ws4vn.Microservicess.ApplicationCore.Interfaces
{
    public interface IEventBus
    {
        Task ExecuteAsync<TEvent>(TEvent @event) where TEvent : DomainEvent;
    }
}