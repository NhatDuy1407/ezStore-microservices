using System.Threading.Tasks;

namespace Microservice.Core.Interfaces
{
    public interface ICommandBus
    {
        Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}