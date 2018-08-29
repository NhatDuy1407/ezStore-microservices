using System.Threading.Tasks;
using Microservice.Core.DomainService.Interfaces;

namespace Microservice.Core.DomainService
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }
}