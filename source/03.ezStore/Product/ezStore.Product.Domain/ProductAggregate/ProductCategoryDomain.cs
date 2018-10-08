using ezStore.Product.Domain.Dtos;
using ezStore.Product.Domain.Mapper;
using ezStore.Product.Infrastructure.Entities;
using ezStore.SharedEvents.Product;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.DomainService.Models;
using System;
using System.Linq;

namespace ezStore.Product.Domain.ProductAggregate
{
    public class ProductCategoryDomain : AggregateRoot
    {
        private readonly IDataAccessWriteService _writeService;

        public ProductCategoryDomain(IDataAccessWriteService writeService)
        {
            _writeService = writeService;
        }

        public void Add(ProductCategoryDto productCategory)
        {
            var newCategory = ProductCategoryMapper.DtoToEntity(productCategory);
            _writeService.Repository<ProductCategory>().Insert(newCategory);
            _writeService.SaveChanges();

            ApplyEvent(new ProductCategoryCreated(newCategory.Id));
        }

        public void Update(ProductCategoryDto productCategory)
        {
            var productCategory2Save = _writeService.Repository<ProductCategory>().Get(i => i.Id == productCategory.Id).FirstOrDefault();
            productCategory2Save.Name = productCategory.Name;
            productCategory2Save.UpdatedDate = DateTime.Now;
            _writeService.SaveChanges();

            ApplyEvent(new ProductCategoryUpdated(productCategory.Id));
        }

        public void Delete(Guid id)
        {
            _writeService.Repository<ProductCategory>().Delete(i => i.Id == id);
            _writeService.SaveChanges();

            ApplyEvent(new ProductCategoryDeleted(id));
        }
    }
}
