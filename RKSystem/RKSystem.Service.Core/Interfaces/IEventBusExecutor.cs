using System.Threading.Tasks;

namespace RKSystem.Service.Core.Interfaces
{
    public interface IEventBusExecutor
    {
        Task ExecuteAsync(IEvent @event);
    }
}
