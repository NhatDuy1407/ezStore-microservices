using System.Threading.Tasks;
using ezStore.Product.ApplicationCore.ProductAggregate;
using ezStore.Product.ApplicationCore.Services.Commands;
using Ws4vn.Microservicess.ApplicationCore.Interfaces;

namespace ezStore.Product.ApplicationCore.Services.CommandHandlers
{
    public class ManufactureCommandHandler
        : ICommandHandler<CreateManufactureCommand>
    {
        private readonly IDomainService _domainService;
        private readonly IDataAccessWriteService writeService;

        public ManufactureCommandHandler(IDomainService domainService, IDataAccessWriteService writeService)
        {
            _domainService = domainService;
            this.writeService = writeService;
        }

        public Task ExecuteAsync(CreateManufactureCommand command)
        {
            var manufactureDomain = new ManufactureDomain(writeService);
            manufactureDomain.Add(new Dtos.ManufactureDto
            {
                Name = command.Name
            });
            
            _domainService.ApplyChanges(manufactureDomain);
            return Task.CompletedTask;
        }
    }
}
