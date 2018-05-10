using System;
using System.Linq.Expressions;

namespace Microservice.Core.DataAccess.Interfaces
{
    public interface IWriteRepository<TModel> : IReadOnlyRepository<TModel>
    {
        void Delete(Expression<Func<TModel, bool>> filter = null);

        void Insert(TModel entity);
    }
}