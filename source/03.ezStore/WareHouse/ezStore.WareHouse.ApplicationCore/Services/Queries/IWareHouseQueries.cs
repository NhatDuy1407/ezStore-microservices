using ezStore.WareHouse.ApplicationCore.Dtos;
using ezStore.WareHouse.ApplicationCore.ReadModels;
using Microservice.DataAccess.Core.Entities;
using System;
using System.Threading.Tasks;

namespace ezStore.WareHouse.ApplicationCore.Services.Queries
{
    public interface IWareHouseQueries
    {
        Task<PagedResult<WareHouseDto>> GetPaged(string name, string orderBy = "", bool orderAsc = true, int page = 1, int pageSize = 20);

        Task<WareHouseDto> Get(Guid id);

        Task<TotalWarehouseReadModel> Get();
    }
}
