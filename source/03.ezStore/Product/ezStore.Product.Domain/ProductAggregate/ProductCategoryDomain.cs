using ezStore.DomainEvents.Product;
using ezStore.Product.Domain.Dtos;
using ezStore.Product.Domain.Mapper;
using ezStore.Product.Infrastructure.Entities;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.DomainService.Models;
using System;
using System.Linq;

namespace ezStore.Product.Domain.ProductAggregate
{
    public class ProductCategoryDomain : AggregateRoot
    {
        private readonly IDataAccessWriteService writeService;

        public ProductCategoryDomain(IDataAccessWriteService writeService)
        {
            this.writeService = writeService;
        }

        public void Add(ProductCategoryDto productCategory)
        {
            var newCategory = ProductCategoryMapper.DtoToEntity(productCategory);
            writeService.Repository<ProductCategory>().Insert(newCategory);
            writeService.SaveChanges();

            ApplyEvent(new ProductCategoryCreated(newCategory.Id));
        }

        public void Update(ProductCategoryDto productCategory)
        {
            var productCategory2Save = writeService.Repository<ProductCategory>().Get(i => i.Id == productCategory.Id).FirstOrDefault();
            productCategory2Save.Name = productCategory.Name;
            productCategory2Save.UpdatedDate = DateTime.Now;
            writeService.SaveChanges();

            ApplyEvent(new ProductCategoryUpdated(productCategory.Id));
        }

        public void Delete(Guid id)
        {
            writeService.Repository<ProductCategory>().Delete(i => i.Id == id);
            writeService.SaveChanges();

            ApplyEvent(new ProductCategoryDeleted(id));
        }
    }
}
