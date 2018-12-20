using Ws4vn.Microservices.ApplicationCore.Exceptions;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using System;
using System.Threading.Tasks;

namespace Ws4vn.Microservices.ApplicationCore.Services
{
    public class CommandBus : ICommandBus
    {
        private readonly IServiceProvider _provider;
        private readonly IValidationContext _validationContext;

        public CommandBus(IServiceProvider provider, IValidationContext validationContext)
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