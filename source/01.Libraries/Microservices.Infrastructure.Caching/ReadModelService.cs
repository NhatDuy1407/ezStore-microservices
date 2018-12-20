using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace Ws4vn.Microservices.Infrastructure.Caching
{
    public class ReadModelService : IReadModelRepository
    {
        private readonly ICacheService CacheService;

        public ReadModelService(ICacheService cacheService)
        {
            CacheService = cacheService;
        }

        public TEntity Read<TEntity>(string key)
        {
            return CacheService.Get<TEntity>(key).Result;
        }

        public void Write<TEntity>(string key, TEntity data)
        {
            CacheService.Set(key, data).Wait();
        }
    }
}
