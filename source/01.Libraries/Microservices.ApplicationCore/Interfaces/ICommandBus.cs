using System.Threading.Tasks;

namespace Microservices.ApplicationCore.Interfaces
{
    public interface ICommandBus
    {
        Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}