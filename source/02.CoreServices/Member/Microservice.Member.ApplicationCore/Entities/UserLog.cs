using MongoDB.Bson;
using Microservice.Core.Models;

namespace Microservice.Member.ApplicationCore.Entities
{
    public class UserLog : ModelEntity<ObjectId>
    {
        public string Content { get; set; }
    }
}
