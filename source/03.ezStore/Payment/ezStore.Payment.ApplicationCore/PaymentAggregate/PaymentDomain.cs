using Microservices.ApplicationCore.Entities;
using Microservices.ApplicationCore.Interfaces;

namespace ezStore.Payment.ApplicationCore.ProductAggregate
{
    public class PaymentDomain : AggregateRoot
    {
        public PaymentDomain(IDataAccessWriteService dataAccessService) : base(dataAccessService)
        {
        }
    }
}
