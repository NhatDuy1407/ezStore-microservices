using Microservice.Core.Models;

namespace Microservice.Core.DomainService.Interfaces
{
    public interface IDomainContext
    {
        void AddEvents(DomainEntity entity);

        void SaveChanges();
    }
}