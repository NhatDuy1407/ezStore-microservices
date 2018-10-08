namespace Microservice.Core.DataAccess.Interfaces
{
    public interface IDataAccessReadOnlyService
    {
        IDataAccessReadOnlyRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}