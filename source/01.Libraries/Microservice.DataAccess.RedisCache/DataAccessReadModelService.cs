using Microservice.Core.CachingService.Interfaces;
using Microservice.DataAccess.Core.Interfaces;

namespace Microservice.DataAccess.RedisCache
{
    public class DataAccessReadModelService : IReadModelRepository
    {
        private readonly ICacheService CacheService;

        public DataAccessReadModelService(ICacheService cacheService)
        {
            CacheService = cacheService;
        }

        public TEntity Read<TEntity>(string key) where TEntity : class
        {
            return CacheService.Get<TEntity>(key).Result;
        }

        public void Write<TEntity>(string key, TEntity data) where TEntity : class
        {
            CacheService.Set(key, data).Wait();
        }
    }
}
