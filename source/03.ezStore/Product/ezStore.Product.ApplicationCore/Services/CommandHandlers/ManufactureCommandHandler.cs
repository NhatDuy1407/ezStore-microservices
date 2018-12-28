using ezStore.Product.ApplicationCore.Dtos;
using ezStore.Product.ApplicationCore.ProductAggregate;
using ezStore.Product.ApplicationCore.Services.Commands;
using System.Threading.Tasks;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace ezStore.Product.ApplicationCore.Services.CommandHandlers
{
    public class ManufactureCommandHandler
        : ICommandHandler<CreateManufactureCommand>
    {
        private readonly IDomainService _domainService;
        private readonly IDataAccessWriteService _writeService;

        public ManufactureCommandHandler(IDomainService domainService, IDataAccessWriteService writeService)
        {
            _domainService = domainService;
            _writeService = writeService;
        }

        public Task ExecuteAsync(CreateManufactureCommand command)
        {
            var productCategoryDomain = new ManufactureDomain(_writeService);
            productCategoryDomain.Add(new ManufactureDto
            {
                Name = command.Name
            });

            _domainService.ApplyChanges(productCategoryDomain);
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(UpdateManufactureCommand command)
        {
            var productCategoryDomain = new ManufactureDomain(_writeService);
            productCategoryDomain.Update(new ManufactureDto
            {
                Id = command.Id,
                Name = command.Name
            });

            _domainService.ApplyChanges(productCategoryDomain);
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(DeleteManufactureCommand command)
        {
            var productCategoryDomain = new ManufactureDomain(_writeService);
            productCategoryDomain.Delete(command.Id);

            _domainService.ApplyChanges(productCategoryDomain);
            return Task.CompletedTask;
        }
    }
}
