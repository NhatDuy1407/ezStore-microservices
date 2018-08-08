using System;
using Microservice.Core.Models;
using MongoDB.Bson;

namespace Microservice.Logging.Persistence.Model
{
    public class AuditLog : ModelEntity
    {
        public ObjectId Id { get; set; }

        public AuditLog()
        {
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        public string Content { get; set; }
    }
}