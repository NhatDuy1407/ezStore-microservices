using System;
using System.Threading.Tasks;
using RKSystem.CacheService.Interfaces;

namespace RKSystem.UserService.WriteSide.Consumers
{
    public class BaseConsumer
    {
        private readonly ICacheService _cacheService;

        public BaseConsumer()
        {
            // write to cache for special data
            _cacheService = new CacheService.CacheService();
        }
        protected async Task WriteCacheAsync(Guid id, object data)
        {
            await _cacheService.Set(id, data);
        }
    }
}
