﻿using Microservice.Core.DomainService.Models;

namespace Microservice.Core.DomainService.Interfaces
{
    public interface IDomainService
    {
        IDomainRepository<TEntity> Repository<TEntity>() where TEntity : DomainEntity;
 

         void SaveChanges();
    }
}