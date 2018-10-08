using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ezStore.Product.Domain.Dtos;

namespace ezStore.Product.Domain.Application.Queries
{
    public interface IProductCategoryQueries
    {
        Task<ProductCategoryDto> Get(Guid id);

        Task<IEnumerable<ProductCategoryDto>> Get();
    }
}
