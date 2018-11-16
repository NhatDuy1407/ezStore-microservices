using ezStore.WareHouse.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ezStore.WareHouse.Domain.Application.Queries
{
    public interface IWareHouseQueries
    {
        Task<WareHouseDto> Get(Guid id);

        Task<IEnumerable<WareHouseDto>> Get();
    }
}
