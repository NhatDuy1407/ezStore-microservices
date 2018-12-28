using ezStore.Product.ApplicationCore.Dtos;
using ezStore.Product.ApplicationCore.Mapper;
using System;
using System.Linq;
using Ws4vn.Microservices.ApplicationCore.Entities;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace ezStore.Product.ApplicationCore.ProductAggregate
{
    public class ProductDomain : AggregateRoot
    {
        public ProductDomain(IDataAccessService dataAccessService) : base(dataAccessService)
        {
        }

        public void Add(ProductDto product)
        {
            var newCategory = ProductMapper.DtoToEntity(product);
            _dataAccessService.Repository<Entities.Product>().Insert(newCategory);

        }

        public void Update(ProductDto product)
        {
            var Product2Save = _dataAccessService.Repository<Entities.Product>().Get(i => i.Id == product.Id).FirstOrDefault();
            Product2Save.Name = product.Name;
            Product2Save.UpdatedDate = DateTime.Now;
        }

        public void Delete(Guid id)
        {
            _dataAccessService.Repository<Entities.Product>().Delete(i => i.Id == id);
        }
    }
}
