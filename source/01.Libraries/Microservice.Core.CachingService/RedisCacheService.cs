using System;
using System.Threading.Tasks;
using Microservice.Core.CachingService.Interfaces;
using ServiceStack.Redis;

namespace Microservice.Core.CachingService
{
    public class RedisCacheService : ICacheService
    {
        private readonly string _connectionString;
        public RedisCacheService(string connectionString)
        {
            _connectionString = connectionString;
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
