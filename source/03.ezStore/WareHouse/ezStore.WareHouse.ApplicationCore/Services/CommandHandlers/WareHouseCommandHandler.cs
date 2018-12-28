using ezStore.WareHouse.ApplicationCore.Services.Commands;
using ezStore.WareHouse.ApplicationCore.WareHouseAggregate;
using System.Threading.Tasks;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace ezStore.WareHouse.ApplicationCore.Services.CommandHandlers
{
    public class WareHouseCommandHandler : ICommandHandler<CreateWareHouseCommand>,
        ICommandHandler<UpdateWareHouseCommand>,
        ICommandHandler<DeleteWareHouseCommand>
    {
        private readonly IDomainService _domainService;
        private readonly IDataAccessWriteService _writeService;

        public WareHouseCommandHandler(IDomainService domainService, IDataAccessWriteService writeService)
        {
            _domainService = domainService;
            _writeService = writeService;
        }

        public Task ExecuteAsync(CreateWareHouseCommand command)
        {
            var wareHouseDomain = new WareHouseDomain(_writeService);
            wareHouseDomain.CreateWareHouse(command.Name, command.CountryId, command.ProvinceId, command.Address, command.City, command.PhoneNumber, command.PostalCode);

            _domainService.ApplyChanges(wareHouseDomain);

            return Task.CompletedTask;
        }

        public Task ExecuteAsync(UpdateWareHouseCommand command)
        {
            var wareHouseDomain = new WareHouseDomain(_writeService);
            wareHouseDomain.UpdateWareHouse(command.Id, command.Name);

            _domainService.ApplyChanges(wareHouseDomain);
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(DeleteWareHouseCommand command)
        {
            var wareHouseDomain = new WareHouseDomain(_writeService);
            wareHouseDomain.DeleteWareHouse(command.Id);

            _domainService.ApplyChanges(wareHouseDomain);
            return Task.CompletedTask;
        }
    }
}
