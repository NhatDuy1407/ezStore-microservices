using ezStore.WareHouse.ApplicationCore.Services.Commands;
using ezStore.WareHouse.ApplicationCore.WareHouseAggregate;
using Microservices.ApplicationCore.Interfaces;
using System.Threading.Tasks;

namespace ezStore.WareHouse.ApplicationCore.Services.CommandHandlers
{
    public class WareHouseCommandHandler : ICommandHandler<CreateWareHouseCommand>,
        ICommandHandler<UpdateWareHouseCommand>,
        ICommandHandler<DeleteWareHouseCommand>
    {
        private readonly IDomainService domainService;
        private readonly IDataAccessWriteService writeService;

        public WareHouseCommandHandler(IDomainService domainService, IDataAccessWriteService writeService)
        {
            this.domainService = domainService;
            this.writeService = writeService;
        }

        public Task ExecuteAsync(CreateWareHouseCommand command)
        {
            var wareHouseDomain = new WareHouseDomain(writeService);
            wareHouseDomain.CreateWareHouse(command.Name);

            domainService.ApplyChanges(wareHouseDomain);

            return Task.CompletedTask;
        }

        public Task ExecuteAsync(UpdateWareHouseCommand command)
        {
            var wareHouseDomain = new WareHouseDomain(writeService);
            wareHouseDomain.UpdateWareHouse(command.Id, command.Name);

            domainService.ApplyChanges(wareHouseDomain);
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(DeleteWareHouseCommand command)
        {
            var wareHouseDomain = new WareHouseDomain(writeService);
            wareHouseDomain.DeleteWareHouse(command.Id);

            domainService.ApplyChanges(wareHouseDomain);
            return Task.CompletedTask;
        }
    }
}
