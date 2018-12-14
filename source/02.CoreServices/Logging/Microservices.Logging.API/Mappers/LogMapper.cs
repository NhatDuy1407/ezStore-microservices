using Microservices.Logging.API.ViewModels;
using Microservices.Logging.ApplicationCore.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace Microservices.Logging.API.Mappers
{
    public static class LogMapper
    {
        public static LogViewModel DtoToViewModel(LogDto dto)
        {
            return new LogViewModel(dto);
        }

        public static IEnumerable<LogViewModel> DtoToViewModels(IEnumerable<LogDto> dtos)
        {
            return dtos?.Select(DtoToViewModel);
        }
    }
}
