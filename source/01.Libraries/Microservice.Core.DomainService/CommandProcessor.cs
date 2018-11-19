using System;
using System.Threading.Tasks;
using Microservice.Core.DomainService.Interfaces;
using Microservice.Core.DomainService.Service;
using Microservice.Core.Service;

namespace Microservice.Core.DomainService
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IServiceProvider _provider;

        public CommandProcessor(IServiceProvider provider)
        {
            _provider = provider;
        }

        public Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
                throw new ArgumentNullException("command");

            if (!command.Validate())
                throw new ValidationErrorException(command.ToString());

            var handler = _provider.GetService(typeof(ICommandHandler<TCommand>));

            if (handler == null)
                throw new CommandHandlerNotFoundException();

            return (handler as ICommandHandler<TCommand>).ExecuteAsync(command);
        }
    }
}