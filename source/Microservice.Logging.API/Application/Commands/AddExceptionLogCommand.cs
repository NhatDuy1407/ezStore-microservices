using Microservice.Core.Service.Models;
using Microservice.Logging.API.Application.ViewModels;

namespace Microservice.Logging.API.Application.Commands
{
    public class AddExceptionLogCommand : Command
    {
        private readonly LogViewModel _info;

        public AddExceptionLogCommand(LogViewModel info)
        {
            _info = info;
        }
    }
}