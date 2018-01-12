using System;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace RKSystem.DataAccess.MongoDB.Interfaces
{
    public interface IRepository<TModel> : IDisposable
    {
        IFindFluent<TModel, TModel> Get(Expression<Func<TModel, bool>> filter = null,
            SortDefinition<TModel> orderBy = null);

        TModel FirstOrDefault(Expression<Func<TModel, bool>> filter = null,
            SortDefinition<TModel> orderBy = null);

        void Delete(Expression<Func<TModel, bool>> filter = null);
        void Insert(TModel entity);
    }
}