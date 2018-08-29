using Microservice.Core.Models;
using MongoDB.Bson;
using System;

namespace Microservice.Member.Infrastructure.Models
{
    public class UserLog : ModelEntity<ObjectId>
    {
        public string Content { get; set; }
    }
}
