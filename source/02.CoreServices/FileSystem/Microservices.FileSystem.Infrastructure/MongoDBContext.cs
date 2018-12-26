using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Security.Authentication;

namespace Microservices.FileSystem.Infrastructure
{
    public class MongoDbContext
    {
        private IMongoDatabase _database { get; }

        public MongoDbContext(string connectionString, string databaseName, bool isSsl)
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
                if (isSsl)
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(databaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Can not access to db server.", ex);
            }
        }

        public IGridFSBucket GetFS()
        {
            return new GridFSBucket(_database);
        }
    }
}