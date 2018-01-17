using System.Threading.Tasks;

namespace RKSystem.Service.Core.Interfaces
{
    public interface ICommandBus
    {
        Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
