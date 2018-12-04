using Microservice.Core.DomainService.Models;
using Microservice.DataAccess.Core.Interfaces;

namespace ezStore.Product.Domain.ProductAggregate
{
    public class ProductDomain : AggregateRoot
    {
        public ProductDomain(IDataAccessService dataAccessService) : base(dataAccessService)
        {
        }
    }
}
