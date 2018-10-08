using System;
using System.Collections;
using Microservice.Core.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Core.DataAccess.Sql
{
    public class DataAccessWriteService : IDataAccessWriteService
    {
        private readonly Hashtable _hashRepository;

        public DataAccessWriteService(DbContext dbContext)
        {
            _hashRepository = new Hashtable();
            Context = dbContext;
        }

        private DbContext Context { get; }

        public IDataAccessWriteRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var key = typeof(TEntity).Name;
            if (!_hashRepository.Contains(key))
            {
                var repositoryType = typeof(BaseModelRepository<>);
                var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), Context);
                _hashRepository[key] = repository;
            }

            return (IDataAccessWriteRepository<TEntity>)_hashRepository[key];
        }


        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}