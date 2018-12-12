using Microservices.ApplicationCore.Entities;
using Microservices.ApplicationCore.Interfaces;

namespace ezStore.Product.ApplicationCore.ProductAggregate
{
    public class ProductDomain : AggregateRoot
    {
        public ProductDomain(IDataAccessService dataAccessService) : base(dataAccessService)
        {
        }
    }
}
