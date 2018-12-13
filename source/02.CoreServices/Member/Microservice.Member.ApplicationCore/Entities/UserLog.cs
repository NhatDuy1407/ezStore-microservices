using MongoDB.Bson;
using Ws4vn.Microservices.ApplicationCore.Entities;

namespace Microservice.Member.ApplicationCore.Entities
{
    public class UserLog : ModelEntity<ObjectId>
    {
        public string Content { get; set; }
    }
}
