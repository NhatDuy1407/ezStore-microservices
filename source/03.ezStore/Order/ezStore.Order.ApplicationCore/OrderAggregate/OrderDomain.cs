using Ws4vn.Microservices.ApplicationCore.Entities;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace ezStore.Order.ApplicationCore.ProductAggregate
{
    public class OrderDomain : AggregateRoot
    {
        public OrderDomain(IDataAccessService dataAccessService) : base(dataAccessService)
        {
        }
    }
}
