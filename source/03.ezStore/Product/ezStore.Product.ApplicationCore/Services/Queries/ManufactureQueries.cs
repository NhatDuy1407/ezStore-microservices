using ezStore.Product.ApplicationCore.Dtos;
using ezStore.Product.ApplicationCore.Entities;
using ezStore.Product.ApplicationCore.Mapper;
using Ws4vn.Microservicess.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ezStore.Product.ApplicationCore.Services.Queries
{
    public class ManufactureQueries : IManufactureQueries
    {
        private readonly IDataAccessReadOnlyService _readOnlyService;

        public ManufactureQueries(IDataAccessReadOnlyService readOnlyService)
        {
            this._readOnlyService = readOnlyService;
        }

        public Task<IEnumerable<ManufactureDto>> Get()
        {
            return Task.FromResult(ManufactureMapper.EntityToDtos(_readOnlyService.Repository<Manufacture>().Get(i => !i.Deleted).ToList()));
        }
        
        public Task<ManufactureDto> Get(Guid id)
        {
            return Task.FromResult(ManufactureMapper.EntityToDto(_readOnlyService.Repository<Manufacture>().Get(i => i.Id == id).FirstOrDefault()));
        }

    }
}
