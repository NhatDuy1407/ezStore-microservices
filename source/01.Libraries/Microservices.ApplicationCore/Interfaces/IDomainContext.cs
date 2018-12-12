using Microservices.ApplicationCore.Entities;

namespace Microservices.ApplicationCore.Interfaces
{
    public interface IDomainContext
    {
        void SaveEvents(AggregateRoot entity);
    }
}