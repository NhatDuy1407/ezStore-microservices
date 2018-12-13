using ezStore.WareHouse.ApplicationCore.Services.Queries;
using ezStore.WareHouse.ApplicationCore.Dtos;
using ezStore.WareHouse.ApplicationCore.Mapper;
using Microservice.DataAccess.Core.Entities;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using ezStore.WareHouse.ApplicationCore.ReadModels;

namespace ezStore.WareHouse.Domain.Application.Queries
{
    public class WareHouseQueries : IWareHouseQueries
    {
        readonly IDataAccessReadOnlyService _readOnlyService;
        readonly ICacheService CacheService;

        public WareHouseQueries(IDataAccessReadOnlyService readOnlyService, ICacheService cacheService)
        {
            _readOnlyService = readOnlyService;
            CacheService = cacheService;
        }

        public Task<PagedResult<WareHouseDto>> GetPaged(string name, string orderBy = "", bool orderAsc = true, int page = 1, int pageSize = 20)
        {
            var data = _readOnlyService.Repository<ApplicationCore.Entities.WareHouse>().GetPaged(i =>
                string.IsNullOrEmpty(name) || i.Name.ToLower().Contains(name.ToLower()), orderBy, orderAsc,
                page: page,
                pageSize: pageSize);
            var result = new PagedResult<WareHouseDto>
            {
                CurrentPage = data.CurrentPage,
                PageCount = data.PageCount,
                PageSize = data.PageSize,
                RowCount = data.RowCount,
                Results = WareHouseMapper.EntityToDtos(data.Results)
            };
            return Task.FromResult(result);
        }

        public Task<WareHouseDto> Get(Guid id)
        {
            return Task.FromResult(WareHouseMapper.EntityToDto(_readOnlyService.Repository<ApplicationCore.Entities.WareHouse>().Get(i => i.Id == id).FirstOrDefault()));
        }

        public Task<TotalWarehouseReadModel> Get()
        {
            var result = new TotalWarehouseReadModel { TotalWarehouse = CacheService.Get<int>("TotalWarehouses").Result };
            return Task.FromResult(result);
        }
    }
}
