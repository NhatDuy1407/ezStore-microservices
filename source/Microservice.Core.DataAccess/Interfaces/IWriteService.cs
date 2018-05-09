using System;

namespace Microservice.Core.DataAccess.Interfaces
{
    public interface IWriteService
    {
        IWriteRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}