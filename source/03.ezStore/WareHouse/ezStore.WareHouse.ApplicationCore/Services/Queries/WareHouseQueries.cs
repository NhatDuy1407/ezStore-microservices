using ezStore.WareHouse.ApplicationCore.Services.Queries;
using ezStore.WareHouse.ApplicationCore.Dtos;
using ezStore.WareHouse.ApplicationCore.Mapper;
using Microservices.DataAccess.Core.Entities;
using Ws4vn.Microservicess.ApplicationCore.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using ezStore.WareHouse.ApplicationCore.ReadModels;
using Ws4vn.Microservicess.ApplicationCore.SharedKernel;
using Ws4vn.Microservices.ApplicationCore.ReadModels;
using System.Collections.Generic;

namespace ezStore.WareHouse.Domain.Application.Queries
{
    public class WareHouseQueries : IWareHouseQueries
    {
        readonly IDataAccessReadOnlyService _readOnlyService;
        readonly IReadModelRepository ReadModelService;

        public WareHouseQueries(IDataAccessReadOnlyService readOnlyService, IReadModelRepository readModelService)
        {
            _readOnlyService = readOnlyService;
            ReadModelService = readModelService;
        }

        public Task<PagedResult<WareHouseDto>> GetPaged(string name, string orderBy = "", bool orderAsc = true, int page = 1, int pageSize = 20)
        {
            var data = _readOnlyService.Repository<ApplicationCore.Entities.Warehouse>().GetPaged(i =>
                string.IsNullOrEmpty(name) || i.Name.ToLower().Contains(name.ToLower()), orderBy, orderAsc,
                page: page,
                pageSize: pageSize);
            var countries = ReadModelService.Read<List<CountryReadModel>>(MicroservicesConstants.CachingCountries);
            var provinces = ReadModelService.Read<List<ProvinceReadModel>>(MicroservicesConstants.CachingProvinces);
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
            var result = new TotalWarehouseReadModel { TotalWarehouse = ReadModelService.Read<int>("TotalWarehouses") };
            return Task.FromResult(result);
        }
    }
}
