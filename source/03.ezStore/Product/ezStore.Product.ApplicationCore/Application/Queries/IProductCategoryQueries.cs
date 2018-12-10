using ezStore.Product.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ezStore.Product.ApplicationCore.Application.Queries
{
    public interface IProductCategoryQueries
    {
        Task<ProductCategoryDto> Get(Guid id);

        Task<IEnumerable<ProductCategoryDto>> Get();
    }
}
