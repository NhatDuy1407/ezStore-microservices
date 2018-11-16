using Microservice.Setting.Domain.Dtos;
using Microservice.Setting.Domain.Mapper;
using Microservice.Core.DataAccess.Entities;
using Microservice.Core.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.Setting.Infrastructure.Entities;

namespace Microservice.Setting.Domain.Application.Queries
{
    public class LocationQueries : ILocationQueries
    {
        private readonly IDataAccessReadOnlyService _readOnlyService;

        public LocationQueries(IDataAccessReadOnlyService readOnlyService)
        {
            _readOnlyService = readOnlyService;
        }

        public Task<IEnumerable<CountryDto>> Get()
        {
            return Task.FromResult(LocationMapper.EntityToDtos(_readOnlyService.Repository<Country>().Get(i => !i.Deleted).ToList()));
        }

        public Task<PagedResult<CountryDto>> GetPaged(string name, string orderBy = "", bool orderAsc = true, int page = 1, int pageSize = 20)
        {
            var data = _readOnlyService.Repository<Country>().GetPaged(i =>
                i.Name.ToString().Contains(name.ToString()) && !i.Deleted,
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

        public Task<CountryDto> Get(string id)
        {
            return Task.FromResult(LocationMapper.EntityToDto(_readOnlyService.Repository<Country>().Get(i => i.CountryId == id).FirstOrDefault()));
        }
    }
}
