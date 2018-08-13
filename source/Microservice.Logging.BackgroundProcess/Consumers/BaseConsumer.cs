using System;
using System.Threading.Tasks;
using Microservice.Core;
using Microservice.Core.CachingService;
using Microservice.Core.CachingService.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Microservice.Logging.BackgroundProcess.Consumers
{
    public class BaseConsumer
    {
        private readonly ICacheService _cacheService;

        public BaseConsumer(IConfiguration configuration, IHostingEnvironment env)
        {
            // write to cache for special data
            if (env.EnvironmentName!="Local")
            {
                _cacheService = new RedisCacheService(configuration.GetConnectionString(Constants.RedisAddress));
            }
            else
            {
                _cacheService = new MongoDbCacheService(configuration.GetConnectionString(Constants.DefaultConnection), configuration.GetConnectionString(Constants.DefaultDatabaseName));
            }
        }

        protected async Task WriteCacheAsync(Guid id, object data)
        {
            await _cacheService.Set(id, data);
        }
    }
}