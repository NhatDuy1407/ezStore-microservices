using System;
using Microservice.Logging.Persistence.Model;

namespace Microservice.Logging.API.Application.ViewModels
{
    public class LogViewModel
    {
        public LogViewModel(LogData i)
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