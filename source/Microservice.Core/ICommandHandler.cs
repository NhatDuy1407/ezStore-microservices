using System.Threading.Tasks;
using Microservice.Core.Interfaces;

namespace Microservice.Core
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }
}