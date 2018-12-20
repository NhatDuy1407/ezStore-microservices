using Ws4vn.Microservices.ApplicationCore.Interfaces;
using ServiceStack.Redis;
using System.Threading.Tasks;

namespace Ws4vn.Microservices.Infrastructure.Caching
{
    public class RedisCacheService : ICacheService
    {
        private readonly string _connectionString;
        public RedisCacheService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task Set<T>(string key, T data)
        {
            var manager = new RedisManagerPool(_connectionString);
            using (var client = manager.GetClient())
            {
                client.Set(key, data);
            }

            return Task.CompletedTask;
        }

        public Task<T> Get<T>(string key)
        {
            var manager = new RedisManagerPool(_connectionString);
            using (var client = manager.GetClient())
            {
                return Task.FromResult(client.Get<T>(key));
            }
        }
    }
}
