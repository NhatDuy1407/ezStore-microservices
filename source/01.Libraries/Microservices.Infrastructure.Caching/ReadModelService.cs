using Ws4vn.Microservicess.ApplicationCore.Interfaces;

namespace Ws4vn.Microservicess.Infrastructure.Caching
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
