using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.DomainService.Models;

namespace ezStore.Payment.Domain.ProductAggregate
{
    public class PaymentDomain : AggregateRoot
    {
        private readonly IDataAccessWriteService writeService;

        public PaymentDomain(IDataAccessWriteService writeService)
        {
            this.writeService = writeService;
        }
    }
}
