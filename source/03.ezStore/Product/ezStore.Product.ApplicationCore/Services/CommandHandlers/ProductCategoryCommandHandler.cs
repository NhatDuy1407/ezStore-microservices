using ezStore.Product.ApplicationCore.Services.Commands;
using ezStore.Product.ApplicationCore.ProductAggregate;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using System.Threading.Tasks;
using ezStore.Product.ApplicationCore.Dtos;

namespace ezStore.Product.ApplicationCore.Services.CommandHandlers
{
    public class ProductCategoryCommandHandler
        : ICommandHandler<CreateProductCategoryCommand>,
        ICommandHandler<UpdateProductCategoryCommand>,
        ICommandHandler<DeleteProductCategoryCommand>
    {
        private readonly IDomainService _domainService;
        private readonly IDataAccessWriteService _writeService;

        public ProductCategoryCommandHandler(IDomainService domainService, IDataAccessWriteService writeService)
        {
            _domainService = domainService;
            _writeService = writeService;
        }

        public Task ExecuteAsync(CreateProductCategoryCommand command)
        {
            var productCategoryDomain = new ProductCategoryDomain(_writeService);
            productCategoryDomain.Add(new ProductCategoryDto
            {
                Name = command.Name
            });

            _domainService.ApplyChanges(productCategoryDomain);
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(UpdateProductCategoryCommand command)
        {
            var productCategoryDomain = new ProductCategoryDomain(_writeService);
            productCategoryDomain.Update(new ProductCategoryDto
            {
                Id = command.Id,
                Name = command.Name
            });

            _domainService.ApplyChanges(productCategoryDomain);
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(DeleteProductCategoryCommand command)
        {
            var productCategoryDomain = new ProductCategoryDomain(_writeService);
            productCategoryDomain.Delete(command.Id);

            _domainService.ApplyChanges(productCategoryDomain);
            return Task.CompletedTask;
        }
    }
}
