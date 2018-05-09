using System.Threading.Tasks;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.Service;
using Microservice.Logging.Domain.ExceptionLoggingAggregate;

namespace Microservice.Logging.API.Application.Commands
{
    public class ExceptionLogCommandHandler : ICommandHandler<AddExceptionLogCommand>
    {
        private readonly IWriteService _writeService;

        public ExceptionLogCommandHandler(IWriteService writeService)
        {
            _writeService = writeService;
        }

        public Task ExecuteAsync(AddExceptionLogCommand command)
        {
            _writeService.Repository<ExceptionLogging>().Insert(new ExceptionLogging());
            return Task.CompletedTask;
        }
    }
}