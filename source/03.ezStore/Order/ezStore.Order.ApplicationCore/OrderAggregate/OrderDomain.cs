using Microservices.ApplicationCore.Entities;
using Microservices.ApplicationCore.Interfaces;

namespace ezStore.Order.ApplicationCore.ProductAggregate
{
    public class OrderDomain : AggregateRoot
    {
        public OrderDomain(IDataAccessService dataAccessService) : base(dataAccessService)
        {
        }
    }
}
