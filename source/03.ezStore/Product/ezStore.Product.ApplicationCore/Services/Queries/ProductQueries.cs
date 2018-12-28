using ezStore.Product.ApplicationCore.Dtos;
using ezStore.Product.ApplicationCore.Mapper;
using Microservices.DataAccess.Core.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace ezStore.Product.ApplicationCore.Services.Queries
{
    public class ProductQueries : IProductQueries
    {
        private readonly IDataAccessReadOnlyService _readOnlyService;

        public ProductQueries(IDataAccessReadOnlyService readOnlyService)
        {
            this._readOnlyService = readOnlyService;
        }
        
        public Task<ProductDto> Get(Guid id)
        {
            return Task.FromResult(ProductMapper.EntityToDto(_readOnlyService.Repository<Entities.Product>().Get(i => i.Id == id).FirstOrDefault()));
        }

        public Task<PagedResult<ProductDto>> GetPaged(string name, string orderBy, bool orderAsc, int page, int pageSize)
        {
            var data = _readOnlyService.Repository<Entities.Product>().GetPaged(i =>
               string.IsNullOrEmpty(name) || i.Name.ToLower().Contains(name.ToLower()), orderBy, orderAsc,
               page: page,
               pageSize: pageSize);
            var result = new PagedResult<ProductDto>
            {
                CurrentPage = data.CurrentPage,
                PageCount = data.PageCount,
                PageSize = data.PageSize,
                RowCount = data.RowCount,
                Results = ProductMapper.EntityToDtos(data.Results)
            };
            return Task.FromResult(result);
        }
    }
}
