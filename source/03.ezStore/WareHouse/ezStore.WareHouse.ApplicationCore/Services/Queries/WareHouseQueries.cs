using ezStore.WareHouse.ApplicationCore.Services.Queries;
using ezStore.WareHouse.ApplicationCore.Dtos;
using ezStore.WareHouse.ApplicationCore.Mapper;
using Microservices.DataAccess.Core.Entities;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using ezStore.WareHouse.ApplicationCore.ReadModels;
using Ws4vn.Microservices.ApplicationCore.SharedKernel;
using Ws4vn.Microservices.ApplicationCore.ReadModels;
using System.Collections.Generic;

namespace ezStore.WareHouse.Domain.Application.Queries
{
    public class WareHouseQueries : IWareHouseQueries
    {
        readonly IDataAccessReadOnlyService _readOnlyService;
        readonly IReadModelRepository _readModelService;

        public WareHouseQueries(IDataAccessReadOnlyService readOnlyService, IReadModelRepository readModelService)
        {
            _readOnlyService = readOnlyService;
            _readModelService = readModelService;
        }

        public Task<PagedResult<WareHouseDto>> GetPaged(string name, string orderBy = "", bool orderAsc = true, int page = 1, int pageSize = 20)
        {
            var data = _readOnlyService.Repository<ApplicationCore.Entities.Warehouse>().GetPaged(i =>
                string.IsNullOrEmpty(name) || i.Name.ToLower().Contains(name.ToLower()), orderBy, orderAsc,
                page: page,
                pageSize: pageSize);
            var countries = _readModelService.Read<List<CountryReadModel>>(MicroservicesConstants.CachingCountries);
            var provinces = _readModelService.Read<List<ProvinceReadModel>>(MicroservicesConstants.CachingProvinces);
            var result = new PagedResult<WareHouseDto>
            {
                CurrentPage = data.CurrentPage,
                PageCount = data.PageCount,
                PageSize = data.PageSize,
                RowCount = data.RowCount,
                Results = WareHouseMapper.EntityToDtos(data.Results, countries, provinces)
            };
            return Task.FromResult(result);
        }

        public Task<WareHouseDto> Get(Guid id)
        {
            return Task.FromResult(WareHouseMapper.EntityToDto(_readOnlyService.Repository<ApplicationCore.Entities.Warehouse>().Get(i => i.Id == id).FirstOrDefault()));
        }

        public Task<TotalWarehouseReadModel> Get()
        {
            var result = new TotalWarehouseReadModel { TotalWarehouse = _readModelService.Read<int>("TotalWarehouses") };
            return Task.FromResult(result);
        }
    }
}
