using Microservices.Setting.ApplicationCore.Entities;
using Microservices.Setting.ApplicationCore.Services.Commands;
using System.Linq;
using System.Threading.Tasks;
using Ws4vn.Microservices.ApplicationCore.ReadModels;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using Ws4vn.Microservices.ApplicationCore.SharedKernel;

namespace Microservices.Setting.ApplicationCore.Services.EventHandlers
{
    public class CacheSettingCommandHandler : ICommandHandler<CacheSettingCommand>
    {
        readonly IReadModelRepository _readModelRepository;
        readonly IDataAccessReadOnlyService _dataAccessReadOnlyService;
        public CacheSettingCommandHandler(IDataAccessReadOnlyService dataAccessReadOnlyService, IReadModelRepository readModelRepository)
        {
            _readModelRepository = readModelRepository;
            _dataAccessReadOnlyService = dataAccessReadOnlyService;
        }

        public Task ExecuteAsync(CacheSettingCommand command)
        {
            if (_readModelRepository.Read<object>(MicroservicesConstants.CachingCountries) == null)
            {
                var countries = _dataAccessReadOnlyService.Repository<Country>().Get()
                    .Select(i => new CountryReadModel()
                    {
                        Id = i.AutoId,
                        Name = i.Name
                    }).ToList();

                _readModelRepository.Write(MicroservicesConstants.CachingCountries, countries);

                var provinces = _dataAccessReadOnlyService.Repository<Province>().Get()
                   .Select(i => new ProvinceReadModel()
                   {
                       Id = i.AutoId,
                       ParentId = i.CountryId,
                       Name = i.Name
                   }).ToList();

                _readModelRepository.Write(MicroservicesConstants.CachingProvinces, provinces);
            }

            return Task.CompletedTask;
        }
    }
}
