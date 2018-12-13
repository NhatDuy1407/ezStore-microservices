using ezStore.WareHouse.ApplicationCore.DomainEvents;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using System.Threading.Tasks;

namespace ezStore.WareHouse.ApplicationCore.Application.EventHandlers
{
    public class WareHouseEventHandler : IEventHandler<WareHouseCreated>
    {
        readonly ICacheService CacheService;

        public WareHouseEventHandler(ICacheService cacheService)
        {
            CacheService = cacheService;
        }

        public Task ExecuteAsync<WareHouseCreated>(WareHouseCreated domainEvent)
        {
            // update read model
            var totalWarehouses = CacheService.Get<int>("TotalWarehouses").Result;
            CacheService.Set("TotalWarehouses", totalWarehouses + 1);

            return Task.CompletedTask;
        }
    }
}
