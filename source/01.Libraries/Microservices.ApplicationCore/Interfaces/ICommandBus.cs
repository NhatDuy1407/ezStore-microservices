using System.Threading.Tasks;

namespace Ws4vn.Microservices.ApplicationCore.Interfaces
{
    public interface ICommandBus
    {
        Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}