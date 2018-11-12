using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.DomainService.Models;

namespace ezStore.WareHouse.Domain.ProductAggregate
{
    public class ProductDomain : AggregateRoot
    {
        private readonly IDataAccessWriteService _writeService;

        public ProductDomain(IDataAccessWriteService writeService)
        {
            _writeService = writeService;
        }
    }
}
