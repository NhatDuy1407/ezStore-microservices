using MongoDB.Bson;
using System;
using Microservice.Core.Models;

namespace Microservice.Logging.Infrastructure
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
    }
}