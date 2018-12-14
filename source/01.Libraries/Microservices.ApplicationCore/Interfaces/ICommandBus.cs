using System.Threading.Tasks;

namespace Ws4vn.Microservicess.ApplicationCore.Interfaces
{
    public interface ICommandBus
    {
        Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}