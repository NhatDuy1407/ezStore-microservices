using Microservice.Core.DomainService.Models;
using Microservice.DataAccess.Core.Interfaces;

namespace ezStore.Payment.ApplicationCore.ProductAggregate
{
    public class PaymentDomain : AggregateRoot
    {
        public PaymentDomain(IDataAccessWriteService dataAccessService) : base(dataAccessService)
        {
        }
    }
}
