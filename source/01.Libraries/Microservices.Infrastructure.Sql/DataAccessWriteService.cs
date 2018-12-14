using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using Ws4vn.Microservicess.ApplicationCore.Interfaces;

namespace Ws4vn.Microservicess.Infrastructure.Sql
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