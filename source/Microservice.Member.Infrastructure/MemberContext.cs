using Microservice.Core.DataAccess.MongoDB;

namespace Microservice.Member.Infrastructure
{
    public class MemberContext : MongoDbContext
    {
        public MemberContext(string connectionString, string databaseName, bool isSsl) : base(connectionString, databaseName, isSsl)
        {
        }
    }
}