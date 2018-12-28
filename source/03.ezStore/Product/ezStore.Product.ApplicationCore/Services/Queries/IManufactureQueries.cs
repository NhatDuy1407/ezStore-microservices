using ezStore.Product.ApplicationCore.Dtos;
using Microservices.DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ezStore.Product.ApplicationCore.Services.Queries
{
    public interface IManufactureQueries
    {
        Task<ManufactureDto> Get(Guid id);

        Task<PagedResult<ManufactureDto>> GetPaged(string name, string orderBy, bool orderAsc, int page, int pageSize);
    }
}
