using System;
using System.Linq.Expressions;

namespace Microservice.DataAccess.Core.Interfaces
{
    public interface IDataAccessWriteRepository<TModel> : IDataAccessReadOnlyRepository<TModel> where TModel : class
    {
        void Delete(Expression<Func<TModel, bool>> filter = null);

        void Insert(TModel entity);

        void Save(TModel entity);

        void SaveChange();
    }
}