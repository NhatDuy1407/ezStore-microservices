using Microservice.Logging.ApplicationCore.Entities;
using System;

namespace Microservice.Logging.ApplicationCore.Dtos
{
    public class LogDto
    {
        public LogDto(LogData i)
        {
            Date = i.Date;
            Level = i.Level;
            Thread = i.Thread;
            Logger = i.Logger;
            Message = i.Message;
        }

        public DateTime Date { get; }
        public string Level { get; }
        public string Thread { get; }
        public string Logger { get; }
        public string Message { get; }
    }
}