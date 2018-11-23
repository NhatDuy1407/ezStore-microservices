using MongoDB.Bson;
using Ws4vn.Core.Models;

namespace Microservice.Member.Infrastructure.Models
{
    public class UserLog : ModelEntity<ObjectId>
    {
        public string Content { get; set; }
    }
}
