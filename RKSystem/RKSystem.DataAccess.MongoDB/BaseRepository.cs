using System;
using System.Linq.Expressions;
using MongoDB.Driver;
using RKSystem.DataAccess.MongoDB.Interfaces;

namespace RKSystem.DataAccess.MongoDB
{
    public class BaseRepository<TModel> : IWriteRepository<TModel> where TModel : class
    {
        protected readonly MongoDbContext Context;
        internal IMongoCollection<TModel> DbSet;

        public BaseRepository(MongoDbContext context)
        {
            Context = context;
            DbSet = Context.Set<TModel>();
        }

        public IFindFluent<TModel, TModel> Get(Expression<Func<TModel, bool>> filter = null,
            SortDefinition<TModel> orderBy = null)
        {
            if (filter == null)
                filter = i => true;
            return DbSet.Find(filter);
        }

        public TModel FirstOrDefault(Expression<Func<TModel, bool>> filter = null,
            SortDefinition<TModel> orderBy = null)
        {
            return Get(filter, orderBy).Limit(1).FirstOrDefault();
        }

        public void Delete(Expression<Func<TModel, bool>> filter = null)
        {
            DbSet.DeleteOne(filter);
        }

        public void Insert(TModel entity)
        {
            DbSet.InsertOne(entity);
        }

        #region disposed

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}