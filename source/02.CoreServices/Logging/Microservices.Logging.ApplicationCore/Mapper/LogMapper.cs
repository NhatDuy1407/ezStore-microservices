﻿using Microservices.Logging.ApplicationCore.Dtos;
using Microservices.Logging.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microservices.Logging.ApplicationCore.Mapper
{
    public static class LogMapper
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

        public static IEnumerable<LogDto> EntityToDtos(IEnumerable<LogData> entities)
        {
            return entities?.Select(EntityToDto);
        }
    }
}
