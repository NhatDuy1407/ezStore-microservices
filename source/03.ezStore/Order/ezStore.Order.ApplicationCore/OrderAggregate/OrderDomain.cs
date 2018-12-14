using Ws4vn.Microservicess.ApplicationCore.Entities;
using Ws4vn.Microservicess.ApplicationCore.Interfaces;

namespace ezStore.Order.ApplicationCore.ProductAggregate
{
    public class OrderDomain : AggregateRoot
    {
        public OrderDomain(IDataAccessService dataAccessService) : base(dataAccessService)
        {
        }
    }
}
