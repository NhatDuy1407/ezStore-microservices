using System;
using System.Threading.Tasks;
using Microservice.Core.CachingService;
using Microservice.Core.CachingService.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Microservice.Service.UserService.WriteSide.Consumers
{
    public class BaseConsumer
    {
        private readonly ICacheService _cacheService;

        public BaseConsumer(IConfiguration configuration)
        {
            // write to cache for special data
            _cacheService = new RedisCacheService(configuration.GetConnectionString("RedisAddress"));
        }
        protected async Task WriteCacheAsync(Guid id, object data)
        {
            await _cacheService.Set(id, data);
        }
    }
}
