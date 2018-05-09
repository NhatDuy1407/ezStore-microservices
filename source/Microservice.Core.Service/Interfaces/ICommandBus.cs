using System.Threading.Tasks;

namespace Microservice.Core.Service.Interfaces
{
    public interface ICommandBus
    {
        Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
