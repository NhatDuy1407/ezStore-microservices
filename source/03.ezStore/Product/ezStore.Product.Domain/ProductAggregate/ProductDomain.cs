using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.DomainService.Models;

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
