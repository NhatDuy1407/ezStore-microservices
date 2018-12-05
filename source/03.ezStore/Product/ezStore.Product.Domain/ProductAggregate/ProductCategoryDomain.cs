using ezStore.DomainEvents.Product;
using ezStore.Product.Domain.Dtos;
using ezStore.Product.Domain.Mapper;
using ezStore.Product.Infrastructure.Entities;
using Microservice.Core.DomainService.Models;
using Microservice.DataAccess.Core.Interfaces;
using System;
using System.Linq;

namespace ezStore.Product.Domain.ProductAggregate
{
    public class ProductCategoryDomain : AggregateRoot
    {
        public ProductCategoryDomain(IDataAccessService dataAccessService) : base(dataAccessService)
        {
        }

        public void Add(ProductCategoryDto productCategory)
        {
            var newCategory = ProductCategoryMapper.DtoToEntity(productCategory);
            dataAccessService.Repository<ProductCategory>().Insert(newCategory);

            ApplyEvent(new ProductCategoryCreated(newCategory.Id));
        }

        public void Update(ProductCategoryDto productCategory)
        {
            var productCategory2Save = dataAccessService.Repository<ProductCategory>().Get(i => i.Id == productCategory.Id).FirstOrDefault();
            productCategory2Save.Name = productCategory.Name;
            productCategory2Save.UpdatedDate = DateTime.Now;

            ApplyEvent(new ProductCategoryUpdated(productCategory.Id));
        }

        public void Delete(Guid id)
        {
            dataAccessService.Repository<ProductCategory>().Delete(i => i.Id == id);

            ApplyEvent(new ProductCategoryDeleted(id));
        }
    }
}
