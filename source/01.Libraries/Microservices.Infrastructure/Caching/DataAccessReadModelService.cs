using Microservices.ApplicationCore.Interfaces;
using Microservices.ApplicationCore.Interfaces;

namespace Microservices.Infrastructure.Caching
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
