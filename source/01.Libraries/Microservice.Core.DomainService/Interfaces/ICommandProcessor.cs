using System.Threading.Tasks;

namespace Microservice.Core.DomainService.Interfaces
{
    public interface ICommandProcessor
    {
        Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}