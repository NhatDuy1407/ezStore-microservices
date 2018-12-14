using Ws4vn.Microservicess.ApplicationCore.Entities;

namespace Ws4vn.Microservicess.ApplicationCore.Interfaces
{
    public interface IDomainContext
    {
        void SaveEvents(AggregateRoot entity);
    }
}