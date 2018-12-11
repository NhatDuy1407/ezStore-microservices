using Microservice.Core.DomainService.Models;

namespace Microservice.Core.DomainService.Interfaces
{
    public interface IDomainContext
    {
        void SaveEvents(AggregateRoot entity);
    }
}