using Microservice.Core.DataAccess.MongoDB;

namespace Microservice.Logging.Infrastructure
{
    public class LoggingContext : MongoDbContext
    {
        public LoggingContext(string connectionString, string databaseName, bool isSsl) : base(connectionString, databaseName, isSsl)
        {
        }
    }
}