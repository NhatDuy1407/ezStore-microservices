using System;
using System.Linq;
using System.Linq.Expressions;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Microservice.Core.DataAccess.MongoDB
{
    public class BaseModelRepository<TModel> : IDataAccessWriteRepository<TModel> where TModel : ModelEntity<ObjectId>
    {
        protected readonly MongoDbContext Context;
        internal IMongoCollection<TModel> DbSet;

        public BaseModelRepository(MongoDbContext context)
        {
            Context = context;
            DbSet = Context.Set<TModel>();
        }

        public IQueryable<TModel> Get(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
             string includeProperties = "", bool isIncludedIsDeleted = true)
        {
            if (filter == null)
                filter = i => true;

            var filterDefinition = Builders<TModel>.Filter.And(filter);

            if (typeof(TModel).GetProperty("Deleted") != null && isIncludedIsDeleted)
            {
                var param = Expression.Parameter(typeof(TModel), "x");
                var body = Expression.NotEqual(Expression.Property(param, "Deleted"),
                    Expression.Convert(Expression.Constant(true), typeof(bool)));
                var isDeletedFilter = Expression.Lambda<Func<TModel, bool>>(body, param);

                filterDefinition = Builders<TModel>.Filter.And(filterDefinition, isDeletedFilter);
            }

            var query = DbSet.Find(filterDefinition).ToListAsync().Result.AsQueryable();
            return orderBy != null ? orderBy(query) : query;
        }

        public TModel FirstOrDefault(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
             string includeProperties = "", bool isIncludedIsDeleted = true)
        {
            return Get(filter, orderBy, includeProperties, isIncludedIsDeleted).FirstOrDefault();
        }

        public void Delete(Expression<Func<TModel, bool>> filter = null)
        {
            DbSet.DeleteOne(filter);
        }

        public void Insert(TModel entity)
        {
            DbSet.InsertOne(entity);
        }

        public void Save(TModel entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChange()
        {
            throw new NotImplementedException();
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