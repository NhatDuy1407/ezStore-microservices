using ezStore.Product.ApplicationCore.Dtos;
using Microservices.DataAccess.Core.Entities;
using System;
using System.Threading.Tasks;

namespace ezStore.Product.ApplicationCore.Services.Queries
{
    public interface IProductCategoryQueries
    {
        Task<ProductCategoryDto> Get(Guid id);

        Task<PagedResult<ProductCategoryDto>> GetPaged(string name, string orderBy, bool orderAsc, int page, int pageSize);
    }
}
