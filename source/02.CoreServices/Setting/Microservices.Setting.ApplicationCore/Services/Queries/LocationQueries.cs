using Microservices.DataAccess.Core.Entities;
using Microservices.Setting.ApplicationCore.Dtos;
using Microservices.Setting.ApplicationCore.Entities;
using Microservices.Setting.ApplicationCore.Mapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ws4vn.Microservicess.ApplicationCore.Interfaces;

namespace Microservices.Setting.ApplicationCore.Services.Queries
{
    public class LocationQueries : ILocationQueries
    {
        private readonly IDataAccessReadOnlyService _readOnlyService;

        public LocationQueries(IDataAccessReadOnlyService readOnlyService)
        {
            _readOnlyService = readOnlyService;
        }

        public Task<IEnumerable<CountryDto>> GetCountries()
        {
            return Task.FromResult(LocationMapper.EntityToDtos(_readOnlyService.Repository<Country>().Get(i => !i.Deleted).ToList()));
        }

        public Task<PagedResult<CountryDto>> GetPaged(string name, string orderBy = "", bool orderAsc = true, int page = 1, int pageSize = 20)
        {
            var data = _readOnlyService.Repository<Country>().GetPaged(i =>
                string.IsNullOrEmpty(name) || i.Name.ToLower().Contains(name.ToLower()),
                page: page,
                pageSize: pageSize);
            var result = new PagedResult<CountryDto>
            {
                CurrentPage = data.CurrentPage,
                PageCount = data.PageCount,
                PageSize = data.PageSize,
                RowCount = data.RowCount,
                Results = LocationMapper.EntityToDtos(data.Results)
            };
            return Task.FromResult(result);
        }

        public Task<CountryDto> GetCountry(int id)
        {
            var country = _readOnlyService.Repository<Country>().Get(i => i.AutoId == id).FirstOrDefault();
            var countryDto = LocationMapper.EntityToDto(country);
            var provinces = _readOnlyService.Repository<Province>().Get(i => i.CountryId == id).ToList();
            countryDto.Provinces = LocationMapper.EntityToDtos(provinces).ToList();
            return Task.FromResult(countryDto);
        }
    }
}
