﻿using ezStore.Product.ApplicationCore.Application.Commands;
using ezStore.Product.ApplicationCore.ProductAggregate;
using Microservices.ApplicationCore.Interfaces;
using System.Threading.Tasks;

namespace ezStore.Product.ApplicationCore.Application.CommandHandlers
{
    public class ProductCategoryCommandHandler
        : ICommandHandler<CreateProductCategoryCommand>,
        ICommandHandler<UpdateProductCategoryCommand>,
        ICommandHandler<DeleteProductCategoryCommand>
    {
        private readonly IDomainService _domainService;
        private readonly IDataAccessWriteService writeService;

        public ProductCategoryCommandHandler(IDomainService domainService, IDataAccessWriteService writeService)
        {
            _domainService = domainService;
            this.writeService = writeService;
        }

        public Task ExecuteAsync(CreateProductCategoryCommand command)
        {
            var productCategoryDomain = new ProductCategoryDomain(writeService);
            productCategoryDomain.Add(new Dtos.ProductCategoryDto
            {
                Name = command.Name
            });

            _domainService.ApplyChanges(productCategoryDomain);
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(UpdateProductCategoryCommand command)
        {
            var productCategoryDomain = new ProductCategoryDomain(writeService);
            productCategoryDomain.Update(new Dtos.ProductCategoryDto
            {
                Id = command.Id,
                Name = command.Name
            });

            _domainService.ApplyChanges(productCategoryDomain);
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(DeleteProductCategoryCommand command)
        {
            var productCategoryDomain = new ProductCategoryDomain(writeService);
            productCategoryDomain.Delete(command.Id);

            _domainService.ApplyChanges(productCategoryDomain);
            return Task.CompletedTask;
        }
    }
}
