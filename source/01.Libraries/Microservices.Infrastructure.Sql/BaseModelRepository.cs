using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using Microservice.DataAccess.Core;
using Microservice.DataAccess.Core.Entities;
using Microservices.ApplicationCore.Interfaces;
using Microservices.ApplicationCore.SharedKernel;

namespace Microservices.Infrastructure.Sql
{
    public class BaseModelRepository<TModel> : IDataAccessWriteRepository<TModel> where TModel : class
    {
        protected readonly DbContext Context;
        internal DbSet<TModel> DbSet;

        public BaseModelRepository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<TModel>();
        }

        public virtual IQueryable<TModel> Get(Expression<Func<TModel, bool>> filter,
             Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy,
             string includeProperties = "", bool isIncludedIsDeleted = true)
        {
            IQueryable<TModel> query = DbSet;

            if (typeof(TModel).GetProperty("Deleted") != null && isIncludedIsDeleted)
            {
                var param = Expression.Parameter(typeof(TModel), "x");
                var body = Expression.NotEqual(Expression.Property(param, "Deleted"),
                    Expression.Convert(Expression.Constant(true), typeof(bool)));
                var isDeletedFilter = Expression.Lambda<Func<TModel, bool>>(body, param);
                query = query.Where(isDeletedFilter);
            }

            if (filter != null)
                query = query.Where(filter);

            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

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
            if (!string.IsNullOrEmpty(orderBy))
            {
                var orderQuery = DbSet.ApplyOrder(orderBy, methodName);
                Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderByFunc = i => orderQuery;
                return Get(filter, orderByFunc, includeProperties, isIncludedIsDeleted);
            }
            return Get(filter, null, includeProperties, isIncludedIsDeleted);
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

            if (!string.IsNullOrEmpty(orderBy))
            {
                var orderQuery = DbSet.ApplyOrder(orderBy, methodName);
                Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderByFunc = i => orderQuery;
                return GetPaged(filter, orderByFunc, includeProperties, isIncludedIsDeleted);
            }
            return GetPaged(filter, null, includeProperties, isIncludedIsDeleted, page, pageSize);
        }

        public TModel FirstOrDefault(Expression<Func<TModel, bool>> filter = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
             string includeProperties = "", bool isIncludedIsDeleted = true)
        {
            return Get(filter, orderBy, includeProperties, isIncludedIsDeleted).FirstOrDefault();
        }

        public void Save(TModel entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Insert(TModel entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(Expression<Func<TModel, bool>> filter = null)
        {
            foreach (var entity in DbSet.Where(filter))
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                    DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public void SaveChange()
        {
            Context.SaveChanges();
        }

        public void Transaction()
        {
            Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            Context.Database.CurrentTransaction.Commit();
        }

        public void Rollback()
        {
            Context.Database.CurrentTransaction.Rollback();
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