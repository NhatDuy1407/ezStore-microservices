using Microservice.Logging.Domain.Dtos;
using Microservice.Logging.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microservice.Logging.Domain.Mapper
{
    public static class ProductCategoryMapper
    {
        public static LogData DtoToEntity(LogDto dto)
        {
            return new LogData
            {
                Date = dto.Date,
                Level = dto.Level,
                Thread = dto.Thread,
                Logger = dto.Logger,
                Message = dto.Message,
                UpdatedDate = DateTime.Now
            };
        }

        public static LogDto EntityToDto(LogData dto)
        {
            return new LogDto(dto);
        }

        public static IEnumerable<LogDto> EntityToDtos(IEnumerable<LogData> dtos)
        {
            return dtos.Select(EntityToDto);
        }
    }
}
