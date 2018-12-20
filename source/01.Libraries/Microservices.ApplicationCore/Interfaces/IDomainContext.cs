using Ws4vn.Microservices.ApplicationCore.Entities;

namespace Ws4vn.Microservices.ApplicationCore.Interfaces
{
    public interface IDomainContext
    {
        void SaveEvents(AggregateRoot entity);
    }
}