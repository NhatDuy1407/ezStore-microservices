﻿using Microservices.DataAccess.Core.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Linq.Expressions;
using Ws4vn.Microservices.ApplicationCore.Entities;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using Ws4vn.Microservices.ApplicationCore.SharedKernel;

namespace Ws4vn.Microservices.Infrastructure.MongoDB
{
    public class BaseModelRepository<TModel> : IDataAccessWriteRepository<TModel> where TModel : ModelEntity<ObjectId>
    {
        protected readonly MongoDbContext _context;
        internal IMongoCollection<TModel> _dbSet;

        public BaseModelRepository(MongoDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TModel>();
        }

        public IQueryable<TModel> Get(Expression<Func<TModel, bool>> filter,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy,
            string includeProperties = "", bool isIncludedIsDeleted = true)
        {
            var query = GetQueryable(filter, isIncludedIsDeleted);
            return orderBy != null ? orderBy(query) : query;
        }

        public virtual IQueryable<TModel> Get(Expression<Func<TModel, bool>> filter = null,
             string orderBy = null, bool orderAsc = true,
             string includeProperties = "", bool isIncludedIsDeleted = true)
        {
            string methodName = "";
            if (orderAsc)
            {
                methodName = "OrderBy";
            }
            else
            {
                methodName = "OrderByDescending";
            }
            var query = GetQueryable(filter, isIncludedIsDeleted);
            if (!string.IsNullOrEmpty(orderBy))
            {
                var orderQuery = query.ApplyOrder(orderBy, methodName);
                IOrderedQueryable<TModel> orderByFunc(IQueryable<TModel> i) => orderQuery;
                return Get(filter, orderByFunc, includeProperties, isIncludedIsDeleted);
            }
            return Get(filter, null, includeProperties, isIncludedIsDeleted);
        }

        private IQueryable<TModel> GetQueryable(Expression<Func<TModel, bool>> filter = null,
            bool isIncludedIsDeleted = true)
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

            // Todo: optimize order
            return _dbSet.Find(filterDefinition).ToListAsync().Result.AsQueryable();
        }

        public PagedResult<TModel> GetPaged(Expression<Func<TModel, bool>> filter,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy,
            string includeProperties = "", bool isIncludedIsDeleted = true,
            int page = 1, int pageSize = 20)
        {
            IQueryable<TModel> query = Get(filter, orderBy, includeProperties, isIncludedIsDeleted);
            var result = new PagedResult<TModel>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }

        public PagedResult<TModel> GetPaged(Expression<Func<TModel, bool>> filter = null,
            string orderBy = null, bool orderAsc = true,
           string includeProperties = "", bool isIncludedIsDeleted = true,
           int page = 1, int pageSize = 20)
        {
            string methodName = "";
            if (orderAsc)
            {
                methodName = "OrderBy";
            }
            else
            {
                methodName = "OrderByDescending";
            }
            var query = GetQueryable(filter, isIncludedIsDeleted);
            if (!string.IsNullOrEmpty(orderBy))
            {
                var orderQuery = query.ApplyOrder(orderBy, methodName);
                IOrderedQueryable<TModel> orderByFunc(IQueryable<TModel> i) => orderQuery;
                return GetPaged(filter, orderByFunc, includeProperties, isIncludedIsDeleted);
            }
            return GetPaged(filter, null, includeProperties, isIncludedIsDeleted, page, pageSize);
        }

        public TModel FirstOrDefault(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
             string includeProperties = "", bool isIncludedIsDeleted = true)
        {
            return Get(filter, orderBy, includeProperties, isIncludedIsDeleted).FirstOrDefault();
        }

        public void Delete(Expression<Func<TModel, bool>> filter = null)
        {
            _dbSet.DeleteOne(filter);
        }

        public void Insert(TModel entity)
        {
            _dbSet.InsertOne(entity);
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