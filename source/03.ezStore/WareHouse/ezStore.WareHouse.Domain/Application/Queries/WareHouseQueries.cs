using ezStore.WareHouse.Domain.Dtos;
using ezStore.WareHouse.Domain.Mapper;
using Microservice.Core.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ezStore.Product.Domain.Application.Queries
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
            return Task.FromResult(WareHouseMapper.EntityToDtos(_readOnlyService.Repository<WareHouse.Infrastructure.Entities.WareHouse>().Get(i => !i.Deleted).ToList()));
        }
        
        public Task<WareHouseDto> Get(Guid id)
        {
            return Task.FromResult(WareHouseMapper.EntityToDto(_readOnlyService.Repository<WareHouse.Infrastructure.Entities.WareHouse>().Get(i => i.Id == id).FirstOrDefault()));
        }

    }
}
