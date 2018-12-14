using System.Threading.Tasks;

namespace Ws4vn.Microservicess.ApplicationCore.Interfaces
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }
}