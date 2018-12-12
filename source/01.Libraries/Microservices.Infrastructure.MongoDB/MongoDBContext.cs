using Microservices.ApplicationCore.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication;

namespace Microservices.Infrastructure.MongoDB
{
    public class MongoDbContext
    {
        public List<IEvent> Events { get; private set; }

        private readonly Hashtable _hashRepository;

        public MongoDbContext(string connectionString, string databaseName, bool isSsl)
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
                if (isSsl)
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };
                var mongoClient = new MongoClient(settings);
                Database = mongoClient.GetDatabase(databaseName);

                _hashRepository = new Hashtable();
            }
            catch (Exception ex)
            {
                throw new Exception("Can not access to db server.", ex);
            }
        }

        private IMongoDatabase Database { get; }

        public IMongoCollection<TEntity> Set<TEntity>() where TEntity : class
        {
            var key = typeof(TEntity).Name;
            if (!_hashRepository.Contains(key))
                _hashRepository[key] = Database.GetCollection<TEntity>(key);

            return (IMongoCollection<TEntity>)_hashRepository[key];
        }

        public void SaveChanges()
        {
            // Method intentionally left empty.
        }
    }
}