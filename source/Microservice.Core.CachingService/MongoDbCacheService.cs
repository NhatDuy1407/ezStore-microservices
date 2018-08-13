using System;
using System.Threading.Tasks;
using Microservice.Core.CachingService.Interfaces;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.DataAccess.MongoDB;
using ServiceStack.Redis;

namespace Microservice.Core.CachingService
{
    public class MongoDbCacheService : ICacheService
    {
        private readonly string _connectionString;
        private readonly IWriteService _writeService;
        public MongoDbCacheService(string connectionString, string databaseName)
        {
            _writeService = new WriteService(new MongoDbContext(connectionString, databaseName, false));
        }

        public Task Set<T>(Guid key, T data)
        {
            var manager = new RedisManagerPool(_connectionString);
            using (var client = manager.GetClient())
            {
                client.Set(key.ToString(), data);
            }

            return Task.CompletedTask;
        }

        public Task<T> Get<T>(Guid key)
        {
            var manager = new RedisManagerPool(_connectionString);
            using (var client = manager.GetClient())
            {
                return Task.FromResult(client.Get<T>(key.ToString()));
            }
        }
    }
}
