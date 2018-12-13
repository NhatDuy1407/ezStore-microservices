using Ws4vn.Microservices.ApplicationCore.Entities;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace ezStore.Payment.ApplicationCore.ProductAggregate
{
    public class PaymentDomain : AggregateRoot
    {
        public PaymentDomain(IDataAccessWriteService dataAccessService) : base(dataAccessService)
        {
        }
    }
}
