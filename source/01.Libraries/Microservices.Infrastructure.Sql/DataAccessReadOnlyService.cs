using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using Microservices.ApplicationCore.Interfaces;

namespace Microservices.Infrastructure.Sql
{
    public class DataAccessReadOnlyService : IDataAccessReadOnlyService
    {
        private readonly Hashtable _hashRepository;

        public DataAccessReadOnlyService(DbContext dbContext)
        {
            _hashRepository = new Hashtable();
            Context = dbContext;
        }

        private DbContext Context { get; }

        public IDataAccessReadOnlyRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var key = typeof(TEntity).Name;
            if (!_hashRepository.Contains(key))
            {
                var repositoryType = typeof(BaseModelRepository<>);
                var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), Context);
                _hashRepository[key] = repository;
            }

            return (IDataAccessReadOnlyRepository<TEntity>) _hashRepository[key];
        }
    }
}