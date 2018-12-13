using ezStore.WareHouse.ApplicationCore.DomainEvents;
using Microservices.ApplicationCore.Interfaces;
using System.Threading.Tasks;

namespace ezStore.WareHouse.ApplicationCore.Services.EventHandlers
{
    public class WareHouseEventHandler : IEventHandler<WareHouseCreated>
    {
        readonly ICacheService CacheService;

        public WareHouseEventHandler(ICacheService cacheService)
        {
            CacheService = cacheService;
        }

        public Task ExecuteAsync<WareHouseCreated>(WareHouseCreated @event)
        {
            // update read model
            var totalWarehouses = CacheService.Get<int>("TotalWarehouses").Result;
            CacheService.Set("TotalWarehouses", totalWarehouses + 1);

            // todo: raise Event to SignalR

            return Task.CompletedTask;
        }
    }
}
