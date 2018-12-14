using Ws4vn.Microservicess.ApplicationCore.Entities;
using Ws4vn.Microservicess.ApplicationCore.Interfaces;

namespace ezStore.Payment.ApplicationCore.ProductAggregate
{
    public class PaymentDomain : AggregateRoot
    {
        public PaymentDomain(IDataAccessWriteService dataAccessService) : base(dataAccessService)
        {
        }
    }
}
