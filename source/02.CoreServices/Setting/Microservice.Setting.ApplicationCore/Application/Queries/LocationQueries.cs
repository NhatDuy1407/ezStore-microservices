using Microservice.DataAccess.Core.Entities;
using Microservice.DataAccess.Core.Interfaces;
using Microservice.Setting.ApplicationCore.Dtos;
using Microservice.Setting.ApplicationCore.Entities;
using Microservice.Setting.ApplicationCore.Mapper;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.Setting.ApplicationCore.Application.Queries
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

        public Task<CountryDto> GetCountry(string id)
        {
            var country = _readOnlyService.Repository<Country>().Get(i => i.Id == ObjectId.Parse(id)).FirstOrDefault();
            var countryDto = LocationMapper.EntityToDto(country);
            var provinces = _readOnlyService.Repository<Province>().Get(i => i.CountryId == ObjectId.Parse(id)).ToList();
            countryDto.Provinces = LocationMapper.EntityToDtos(provinces).ToList();
            return Task.FromResult(countryDto);
        }
    }
}
