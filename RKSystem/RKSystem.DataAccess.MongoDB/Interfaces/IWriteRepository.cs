using System;
using System.Linq.Expressions;

namespace RKSystem.DataAccess.MongoDB.Interfaces
{
    public interface IWriteRepository<TModel> : IReadOnlyRepository<TModel>
    {
        void Delete(Expression<Func<TModel, bool>> filter = null);

        void Insert(TModel entity);
    }
}