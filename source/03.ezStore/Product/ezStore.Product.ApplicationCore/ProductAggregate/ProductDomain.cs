using Ws4vn.Microservicess.ApplicationCore.Entities;
using Ws4vn.Microservicess.ApplicationCore.Interfaces;

namespace ezStore.Product.ApplicationCore.ProductAggregate
{
    public class ProductDomain : AggregateRoot
    {
        public ProductDomain(IDataAccessService dataAccessService) : base(dataAccessService)
        {
        }
    }
}
