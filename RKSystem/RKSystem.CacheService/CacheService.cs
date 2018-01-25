using System;
using System.Threading.Tasks;
using RKSystem.CacheService.Interfaces;
using ServiceStack.Redis;

namespace RKSystem.CacheService
{
    public class CacheService : ICacheService
    {
        public Task Set<T>(Guid key, T data)
        {
            var manager = new RedisManagerPool("192.168.0.102:6379");
            using (var client = manager.GetClient())
            {
                client.Set(key.ToString(), data);
            }

            return Task.CompletedTask;
        }

        public Task<T> Get<T>(Guid key)
        {
            var manager = new RedisManagerPool("192.168.0.102:6379");
            using (var client = manager.GetClient())
            {
                return Task.FromResult(client.Get<T>(key.ToString()));
            }
        }
    }
}
