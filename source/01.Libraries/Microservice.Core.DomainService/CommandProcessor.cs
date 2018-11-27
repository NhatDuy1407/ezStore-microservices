using Microservice.Core.DomainService.Interfaces;
using Microservice.Core.DomainService.Service;
using System;
using System.Threading.Tasks;

namespace Microservice.Core.DomainService
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IServiceProvider _provider;
        private readonly IValidationContext _validationContext;

        public CommandProcessor(IServiceProvider provider, IValidationContext validationContext)
        {
            _provider = provider;
            _validationContext = validationContext;
        }

        public Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
                throw new ArgumentNullException("command");

            if (!command.Validate(_validationContext))
                throw new ValidationErrorException(_validationContext.FormatValidationError());

            var handler = _provider.GetService(typeof(ICommandHandler<TCommand>));

            if (handler == null)
                throw new CommandHandlerNotFoundException();

            return (handler as ICommandHandler<TCommand>).ExecuteAsync(command);
        }
    }
}