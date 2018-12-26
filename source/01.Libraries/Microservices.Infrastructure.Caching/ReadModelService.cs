using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace Ws4vn.Microservices.Infrastructure.Caching
{
    public class ReadModelService : IReadModelRepository
    {
        private readonly ICacheService _cacheService;

        public ReadModelService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public TEntity Read<TEntity>(string key)
        {
            return _cacheService.Get<TEntity>(key).Result;
        }

        public void Write<TEntity>(string key, TEntity data)
        {
            _cacheService.Set(key, data).Wait();
        }
    }
}
