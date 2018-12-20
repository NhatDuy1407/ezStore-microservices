﻿using MongoDB.Bson;
using System;
using Ws4vn.Microservices.ApplicationCore.Entities;

namespace Microservices.Logging.ApplicationCore.Entities
{
    public class LogData : ModelEntity<ObjectId>
    {
        public LogData()
        {
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        public DateTime Date { get; set; }
        public string Level { get; set; }
        public string Thread { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
        public string StackTrace { get; set; }
        public string ExceptionTypeName { get; set; }
    }
}