using Ws4vn.Microservices.ApplicationCore.Entities;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace ezStore.Product.ApplicationCore.ProductAggregate
{
    public class ProductDomain : AggregateRoot
    {
        public ProductDomain(IDataAccessService dataAccessService) : base(dataAccessService)
        {
        }
    }
}
