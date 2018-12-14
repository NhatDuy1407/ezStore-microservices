﻿using Microservices.Logging.ApplicationCore.Dtos;
using System;

namespace Microservices.Logging.API.ViewModels
{
    public class LogViewModel
    {
        public LogViewModel(LogDto i)
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