using System;
using System.Linq;
using System.Linq.Expressions;

namespace Microservice.Core.DataAccess.Interfaces
{
    public interface IReadOnlyRepository<TModel> : IDisposable
    {
        IQueryable<TModel> Get(Expression<Func<TModel, bool>> filter = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null);

        TModel FirstOrDefault(Expression<Func<TModel, bool>> filter = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null);
    }
}