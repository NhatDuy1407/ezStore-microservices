using Microservice.Core.DomainService.Models;
using Microservice.DataAccess.Core.Interfaces;

namespace ezStore.Product.Domain.ProductAggregate
{
    public class ProductDomain : AggregateRoot
    {
        private readonly IDataAccessWriteService writeService;

        public ProductDomain(IDataAccessWriteService writeService)
        {
            this.writeService = writeService;
        }
    }
}
