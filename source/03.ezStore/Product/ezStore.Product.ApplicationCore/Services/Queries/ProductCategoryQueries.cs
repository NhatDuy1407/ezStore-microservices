using ezStore.Product.ApplicationCore.Dtos;
using ezStore.Product.ApplicationCore.Entities;
using ezStore.Product.ApplicationCore.Mapper;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using System;
using System.Threading.Tasks;
using Microservices.DataAccess.Core.Entities;
using System.Linq;

namespace ezStore.Product.ApplicationCore.Services.Queries
{
    public class ProductCategoryQueries : IProductCategoryQueries
    {
        private readonly IDataAccessReadOnlyService _readOnlyService;

        public ProductCategoryQueries(IDataAccessReadOnlyService readOnlyService)
        {
            this._readOnlyService = readOnlyService;
        }

        public Task<ProductCategoryDto> Get(Guid id)
        {
            return Task.FromResult(ProductCategoryMapper.EntityToDto(_readOnlyService.Repository<ProductCategory>().Get(i => i.Id == id).FirstOrDefault()));
        }

        public Task<PagedResult<ProductCategoryDto>> GetPaged(string name, string orderBy, bool orderAsc, int page, int pageSize)
        {
            var data = _readOnlyService.Repository<ProductCategory>().GetPaged(i =>
                string.IsNullOrEmpty(name) || i.Name.ToLower().Contains(name.ToLower()), orderBy, orderAsc,
                page: page,
                pageSize: pageSize);
            var result = new PagedResult<ProductCategoryDto>
            {
                CurrentPage = data.CurrentPage,
                PageCount = data.PageCount,
                PageSize = data.PageSize,
                RowCount = data.RowCount,
                Results = ProductCategoryMapper.EntityToDtos(data.Results)
            };
            return Task.FromResult(result);
        }
    }
}
