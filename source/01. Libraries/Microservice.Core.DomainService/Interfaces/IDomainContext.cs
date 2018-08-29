using Microservice.Core.DomainService.Models;
using System.Threading.Tasks;

namespace Microservice.Core.DomainService.Interfaces
{
    public interface IDomainContext
    {
        void AddEvents(DomainEntity entity);

        Task SaveChanges();
    }
}