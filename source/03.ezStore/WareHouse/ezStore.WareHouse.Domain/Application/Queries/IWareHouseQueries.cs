using ezStore.WareHouse.Domain.Dtos;
using Microservice.DataAccess.Core.Entities;
using System;
using System.Threading.Tasks;

namespace ezStore.WareHouse.Domain.Application.Queries
{
    public interface IWareHouseQueries
    {
        Task<PagedResult<WareHouseDto>> GetPaged(string name, string orderBy = "", bool orderAsc = true, int page = 1, int pageSize = 20);

        Task<WareHouseDto> Get(Guid id);
    }
}
