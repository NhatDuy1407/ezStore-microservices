using Microservice.Core.Models;
using MongoDB.Bson;
using System;

namespace Microservice.Logging.Persistence.Model
{
    public class LogData : ModelEntity
    {
        public ObjectId Id { get; set; }

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