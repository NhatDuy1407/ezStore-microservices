using ezStore.WareHouse.Domain.Dtos;
using ezStore.WareHouse.Domain.Mapper;
using Microservice.Core.DataAccess.Entities;
using Microservice.Core.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ezStore.WareHouse.Domain.Application.Queries
{
    public class WareHouseQueries : IWareHouseQueries
    {
        private readonly IDataAccessReadOnlyService _readOnlyService;

        public WareHouseQueries(IDataAccessReadOnlyService readOnlyService)
        {
            _readOnlyService = readOnlyService;
        }

        public Task<IEnumerable<WareHouseDto>> Get()
        {
            return Task.FromResult(WareHouseMapper.EntityToDtos(_readOnlyService.Repository<Infrastructure.Entities.WareHouse>().Get(i => !i.Deleted).ToList()));
        }

        public Task<PagedResult<WareHouseDto>> GetPaged(string name, string orderBy = "", bool orderAsc = true, int page = 1, int pageSize = 20)
        {
            var data = _readOnlyService.Repository<Infrastructure.Entities.WareHouse>().GetPaged(i =>
                i.Name.ToString().Contains(name.ToString()) && !i.Deleted,
                page: page,
                pageSize: pageSize);
            var result = new PagedResult<WareHouseDto>
            {
                CurrentPage = data.CurrentPage,
                PageCount = data.PageCount,
                PageSize = data.PageSize,
                RowCount = data.RowCount,
                Results = WareHouseMapper.EntityToDtos(data.Results)
            };
            return Task.FromResult(result);
        }

        public Task<WareHouseDto> Get(Guid id)
        {
            return Task.FromResult(WareHouseMapper.EntityToDto(_readOnlyService.Repository<Infrastructure.Entities.WareHouse>().Get(i => i.Id == id).FirstOrDefault()));
        }
    }
}
