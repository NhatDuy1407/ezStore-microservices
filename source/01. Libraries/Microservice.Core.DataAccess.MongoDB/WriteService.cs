﻿using System;
using System.Collections;
using Microservice.Core.DataAccess.Interfaces;

namespace Microservice.Core.DataAccess.MongoDB
{
    public class WriteService : IWriteService
    {
        private readonly Hashtable _hashRepository;

        public WriteService(MongoDbContext dbContext)
        {
            _hashRepository = new Hashtable();
            Context = dbContext;
        }

        private MongoDbContext Context { get; }

        public IWriteRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var key = typeof(TEntity).Name;
            if (!_hashRepository.Contains(key))
            {
                var repositoryType = typeof(BaseModelRepository<>);
                var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), Context);
                _hashRepository[key] = repository;
            }

            return (IWriteRepository<TEntity>)_hashRepository[key];
        }


        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}