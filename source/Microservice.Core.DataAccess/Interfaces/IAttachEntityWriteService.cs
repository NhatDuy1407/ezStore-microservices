using Microservice.Core.Models;

namespace Microservice.Core.DataAccess.Interfaces
{
    public interface IAttachEntityWriteService : IWriteService
    {
        void AttachEntity(DomainEntity entity);
    }
}