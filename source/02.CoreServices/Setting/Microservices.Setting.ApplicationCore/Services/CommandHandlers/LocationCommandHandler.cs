using Microservices.Setting.ApplicationCore.Services.Commands;
using Microservices.Setting.ApplicationCore.SettingAggregate;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using System.Threading.Tasks;

namespace Microservices.Setting.ApplicationCore.Services.CommandHandlers
{
    public class LocationCommandHandler : ICommandHandler<CreateCountryCommand>,
        ICommandHandler<UpdateCountryCommand>,
        ICommandHandler<DeleteCountryCommand>
    {
        private readonly IDomainService _domainService;
        private readonly IDataAccessWriteService _writeService;

        public LocationCommandHandler(IDomainService domainService, IDataAccessWriteService writeService)
        {
            _domainService = domainService;
            _writeService = writeService;
        }

        public Task ExecuteAsync(CreateCountryCommand command)
        {
            var locationDomain = new LocationDomain(_writeService);
            locationDomain.CreateCountry(command.Name, command.IsoCode, command.DisplayOrder, command.Published);

            _domainService.ApplyChanges(locationDomain);
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(UpdateCountryCommand command)
        {
            var locationDomain = new LocationDomain(_writeService);
            locationDomain.UpdateCountry(command.Id, command.Name, command.IsoCode, command.DisplayOrder, command.Published);

            _domainService.ApplyChanges(locationDomain);
            return Task.CompletedTask;
        }

        public Task ExecuteAsync(DeleteCountryCommand command)
        {
            var locationDomain = new LocationDomain(_writeService);
            locationDomain.DeleteCountry(command.Id);

            _domainService.ApplyChanges(locationDomain);
            return Task.CompletedTask;
        }
    }
}
