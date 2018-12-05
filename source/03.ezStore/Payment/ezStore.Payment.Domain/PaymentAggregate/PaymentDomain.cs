using Microservice.Core.DomainService.Models;
using Microservice.DataAccess.Core.Interfaces;

namespace ezStore.Payment.Domain.ProductAggregate
{
    public class PaymentDomain : AggregateRoot
    {
        public PaymentDomain(IDataAccessWriteService dataAccessService) : base(dataAccessService)
        {
        }
    }
}
