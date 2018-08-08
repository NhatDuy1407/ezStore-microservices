using Microservice.Core.Models;

namespace Microservice.Core.DataAccess.Interfaces
{
    public interface IDomainContext
    {
        void AddEvents(DomainEntity entity);

        void SaveChanges();
    }
}