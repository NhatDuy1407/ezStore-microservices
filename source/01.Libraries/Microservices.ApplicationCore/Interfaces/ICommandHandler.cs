using System.Threading.Tasks;

namespace Microservices.ApplicationCore.Interfaces
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }
}