using ezStore.Product.Domain.Dtos;
using ezStore.Product.Domain.Mapper;
using ezStore.Product.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.DataAccess.Core.Interfaces;

namespace ezStore.Product.Domain.Application.Queries
{
    public class ProductCategoryQueries : IProductCategoryQueries
    {
        private readonly IDataAccessReadOnlyService _readOnlyService;

        public ProductCategoryQueries(IDataAccessReadOnlyService readOnlyService)
        {
            this._readOnlyService = readOnlyService;
        }

        public Task<IEnumerable<ProductCategoryDto>> Get()
        {
            return Task.FromResult(ProductCategoryMapper.EntityToDtos(_readOnlyService.Repository<ProductCategory>().Get(i => !i.Deleted).ToList()));
        }
        
        public Task<ProductCategoryDto> Get(Guid id)
        {
            return Task.FromResult(ProductCategoryMapper.EntityToDto(_readOnlyService.Repository<ProductCategory>().Get(i => i.Id == id).FirstOrDefault()));
        }

    }
}
