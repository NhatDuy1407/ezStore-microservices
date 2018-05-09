using System.Threading.Tasks;

namespace Microservice.Core.Service.Interfaces
{
    public interface IEventBusExecutor
    {
        Task ExecuteAsync(IEvent @event);
    }
}
