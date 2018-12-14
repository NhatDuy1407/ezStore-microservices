using Ws4vn.Microservicess.ApplicationCore.Events;
using System.Threading.Tasks;

namespace Ws4vn.Microservicess.ApplicationCore.Interfaces
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task ExecuteAsync<TEvent>(TEvent @event);
    }
}