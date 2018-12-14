using Microservices.DataAccess.Core.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Ws4vn.Microservicess.ApplicationCore.Interfaces
{
    public interface IDataAccessReadOnlyRepository<TModel> : IDisposable where TModel : class
    {
        IQueryable<TModel> Get(Expression<Func<TModel, bool>> filter = null,
             string orderBy = null, bool orderAsc = true,
             string includeProperties = "", bool isIncludedIsDeleted = true);

        IQueryable<TModel> Get(Expression<Func<TModel, bool>> filter,
             Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy,
             string includeProperties = "", bool isIncludedIsDeleted = true);

        PagedResult<TModel> GetPaged(Expression<Func<TModel, bool>> filter = null,
            string orderBy = null, bool orderAsc = true,
            string includeProperties = "", bool isIncludedIsDeleted = true,
            int page = 1, int pageSize = 20);

        PagedResult<TModel> GetPaged(Expression<Func<TModel, bool>> filter,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy,
            string includeProperties = "", bool isIncludedIsDeleted = true,
            int page = 1, int pageSize = 20);

        TModel FirstOrDefault(Expression<Func<TModel, bool>> filter = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            string includeProperties = "", bool isIncludedIsDeleted = true);
    }
}