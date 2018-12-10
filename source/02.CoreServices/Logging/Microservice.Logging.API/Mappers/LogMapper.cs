using Microservice.Logging.API.ViewModels;
using Microservice.Logging.Domain.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace Microservice.Logging.API.Mappers
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
