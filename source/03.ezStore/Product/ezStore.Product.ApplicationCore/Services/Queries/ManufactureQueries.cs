using ezStore.Product.ApplicationCore.Dtos;
using ezStore.Product.ApplicationCore.Entities;
using ezStore.Product.ApplicationCore.Mapper;
using Microservices.DataAccess.Core.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace ezStore.Product.ApplicationCore.Services.Queries
{
    public class ManufactureQueries : IManufactureQueries
    {
        private readonly IDataAccessReadOnlyService _readOnlyService;

        public ManufactureQueries(IDataAccessReadOnlyService readOnlyService)
        {
            this._readOnlyService = readOnlyService;
        }
        
        public Task<ManufactureDto> Get(Guid id)
        {
            return Task.FromResult(ManufactureMapper.EntityToDto(_readOnlyService.Repository<Manufacture>().Get(i => i.Id == id).FirstOrDefault()));
        }

        public Task<PagedResult<ManufactureDto>> GetPaged(string name, string orderBy, bool orderAsc, int page, int pageSize)
        {
            var data = _readOnlyService.Repository<Manufacture>().GetPaged(i =>
               string.IsNullOrEmpty(name) || i.Name.ToLower().Contains(name.ToLower()), orderBy, orderAsc,
               page: page,
               pageSize: pageSize);
            var result = new PagedResult<ManufactureDto>
            {
                CurrentPage = data.CurrentPage,
                PageCount = data.PageCount,
                PageSize = data.PageSize,
                RowCount = data.RowCount,
                Results = ManufactureMapper.EntityToDtos(data.Results)
            };
            return Task.FromResult(result);
        }
    }
}
