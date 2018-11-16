using Microservice.Core.Models;
using MongoDB.Bson;

namespace Microservice.Member.Infrastructure.Models
{
    public class UserLog : ModelEntity<ObjectId>
    {
        public string Content { get; set; }
    }
}
