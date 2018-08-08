using Microservice.Core.Models;
using MongoDB.Bson;
using System;

namespace Microservice.Logging.Persistence.Model
{
    public class ExceptionLog : ModelEntity
    {
        public ObjectId Id { get; set; }

        public ExceptionLog()
        {
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        public string Content { get; set; }
    }
}