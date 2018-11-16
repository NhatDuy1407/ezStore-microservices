using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.DomainService.Models;

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
