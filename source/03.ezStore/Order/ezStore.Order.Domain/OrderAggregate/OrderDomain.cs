using Microservice.Core.DomainService.Models;
using Microservice.DataAccess.Core.Interfaces;

namespace ezStore.Order.Domain.ProductAggregate
{
    public class OrderDomain : AggregateRoot
    {
        private readonly IDataAccessWriteService writeService;

        public OrderDomain(IDataAccessWriteService writeService)
        {
            this.writeService = writeService;
        }
    }
}
