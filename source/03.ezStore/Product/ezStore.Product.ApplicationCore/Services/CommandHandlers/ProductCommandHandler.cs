using ezStore.Product.ApplicationCore.Dtos;
using ezStore.Product.ApplicationCore.ProductAggregate;
using ezStore.Product.ApplicationCore.Services.Commands;
using System.Threading.Tasks;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace ezStore.Product.ApplicationCore.Services.CommandHandlers
{
    public class ProductCommandHandler
        : ICommandHandler<CreateProductCommand>
    {
        private readonly IDomainService _domainService;
        private readonly IDataAccessWriteService _writeService;

        public ProductCommandHandler(IDomainService domainService, IDataAccessWriteService writeService)
        {
            _domainService = domainService;
            _writeService = writeService;
        }
        public Task ExecuteAsync(CreateProductCommand command)
        {
            var productCategoryDomain = new ProductDomain(_writeService);
            productCategoryDomain.Add(new ProductDto
            {
                Name = command.Name
            });

            _domainService.ApplyChanges(productCategoryDomain);
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(UpdateProductCommand command)
        {
            var productCategoryDomain = new ProductDomain(_writeService);
            productCategoryDomain.Update(new ProductDto
            {
                Id = command.Id,
                Name = command.Name
            });

            _domainService.ApplyChanges(productCategoryDomain);
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(DeleteProductCommand command)
        {
            var productCategoryDomain = new ProductDomain(_writeService);
            productCategoryDomain.Delete(command.Id);

            _domainService.ApplyChanges(productCategoryDomain);
            return Task.CompletedTask;
        }
    }
}
