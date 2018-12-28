using ezStore.WareHouse.ApplicationCore.DomainEvents;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using System.Threading.Tasks;

namespace ezStore.WareHouse.ApplicationCore.Services.EventHandlers
{
    public class WareHouseEventHandler : IEventHandler<WareHouseCreated>
    {
        readonly ICacheService _cacheService;

        public WareHouseEventHandler(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public Task ExecuteAsync<WareHouseCreated>(WareHouseCreated @event)
        {
            // update read model
            var totalWarehouses = _cacheService.Get<int>("TotalWarehouses").Result;
            _cacheService.Set("TotalWarehouses", totalWarehouses + 1);

            // todo: raise Event to SignalR

            return Task.CompletedTask;
        }
    }
}
