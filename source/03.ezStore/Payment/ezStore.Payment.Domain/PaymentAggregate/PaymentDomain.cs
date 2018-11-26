using Microservice.Core.DomainService.Models;
using Microservice.DataAccess.Core.Interfaces;

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
