using ezStore.WareHouse.Domain.Application.Commands;
using ezStore.WareHouse.Domain.ProductAggregate;
using Microservice.Core.DomainService;
using Microservice.Core.DomainService.Interfaces;
using System.Threading.Tasks;
using Ws4vn.DataAccess.Core.Interfaces;

namespace ezStore.WareHouse.Domain.Application.CommandHandlers
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
            domainService.SaveChanges();
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(UpdateWareHouseCommand command)
        {
            var wareHouseDomain = new WareHouseDomain(writeService);
            wareHouseDomain.UpdateWareHouse(command.Id, command.Name);

            domainService.ApplyChanges(wareHouseDomain);
            domainService.SaveChanges();
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(DeleteWareHouseCommand command)
        {
            var wareHouseDomain = new WareHouseDomain(writeService);
            wareHouseDomain.DeleteWareHouse(command.Id);

            domainService.ApplyChanges(wareHouseDomain);
            domainService.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
