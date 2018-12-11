using System.Threading.Tasks;

namespace Microservice.Core.DomainService.Interfaces
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }
}