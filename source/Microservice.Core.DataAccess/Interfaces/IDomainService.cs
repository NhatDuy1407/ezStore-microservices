using Microservice.Core.Models;
using System;

namespace Microservice.Core.DataAccess.Interfaces
{
    public interface IDomainService
    {
        ISaveRepository<TEntity> Repository<TEntity>() where TEntity : DomainEntity;
 

         void SaveChanges();
    }
}