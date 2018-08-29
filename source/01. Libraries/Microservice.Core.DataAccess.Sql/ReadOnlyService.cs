using System;
using System.Collections;
using Microservice.Core.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Core.DataAccess.Sql
{
    public class ReadOnlyService : IReadOnlyService
    {
        private readonly Hashtable _hashRepository;

        public ReadOnlyService(DbContext dbContext)
        {
            _hashRepository = new Hashtable();
            Context = dbContext;
        }

        private DbContext Context { get; }

        public IReadOnlyRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var key = typeof(TEntity).Name;
            if (!_hashRepository.Contains(key))
            {
                var repositoryType = typeof(BaseModelRepository<>);
                var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), Context);
                _hashRepository[key] = repository;
            }

            return (IReadOnlyRepository<TEntity>) _hashRepository[key];
        }
    }
}