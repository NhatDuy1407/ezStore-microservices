using System.Threading.Tasks;

namespace Microservice.Core.DomainService.Interfaces
{
    public interface ICommandBus
    {
        Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}