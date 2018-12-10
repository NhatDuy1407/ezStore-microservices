using Microservice.Core.DomainService;
using Microservice.Core.DomainService.Interfaces;
using Microservice.DataAccess.Core.Interfaces;
using Microservice.Setting.ApplicationCore.Application.Commands;
using Microservice.Setting.ApplicationCore.SettingAggregate;
using System.Threading.Tasks;

namespace Microservice.Setting.ApplicationCore.Application.CommandHandlers
{
    public class LocationCommandHandler : ICommandHandler<CreateCountryCommand>,
        ICommandHandler<UpdateCountryCommand>,
        ICommandHandler<DeleteCountryCommand>
    {
        private readonly IDomainService domainService;
        private readonly IDataAccessWriteService writeService;

        public LocationCommandHandler(IDomainService domainService, IDataAccessWriteService writeService)
        {
            this.domainService = domainService;
            this.writeService = writeService;
        }

        public Task ExecuteAsync(CreateCountryCommand command)
        {
            var locationDomain = new LocationDomain(writeService);
            locationDomain.CreateCountry(command.Name, command.IsoCode, command.DisplayOrder, command.Published);

            domainService.ApplyChanges(locationDomain);
            domainService.SaveChanges();
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(UpdateCountryCommand command)
        {
            var locationDomain = new LocationDomain(writeService);
            locationDomain.UpdateCountry(command.Id, command.Name, command.IsoCode, command.DisplayOrder, command.Published);

            domainService.ApplyChanges(locationDomain);
            domainService.SaveChanges();
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(DeleteCountryCommand command)
        {
            var locationDomain = new LocationDomain(writeService);
            locationDomain.DeleteCountry(command.Id);

            domainService.ApplyChanges(locationDomain);
            domainService.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
