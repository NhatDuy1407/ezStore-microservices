using MongoDB.Bson;
using Ws4vn.Microservicess.ApplicationCore.Entities;

namespace Microservices.Member.ApplicationCore.Entities
{
    public class UserLog : ModelEntity<ObjectId>
    {
        public string Content { get; set; }
    }
}
