using ezStore.Product.ApplicationCore.Dtos;
using Microservices.DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ezStore.Product.ApplicationCore.Services.Queries
{
    public interface IProductQueries
    {
        Task<ProductDto> Get(Guid id);

        Task<PagedResult<ProductDto>> GetPaged(string name, string orderBy, bool orderAsc, int page, int pageSize);
    }
}
