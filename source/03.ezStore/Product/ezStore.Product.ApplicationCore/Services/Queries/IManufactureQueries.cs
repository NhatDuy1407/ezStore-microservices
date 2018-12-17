using ezStore.Product.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ezStore.Product.ApplicationCore.Services.Queries
{
    public interface IManufactureQueries
    {
        Task<ManufactureDto> Get(Guid id);

        Task<IEnumerable<ManufactureDto>> Get();
    }
}
