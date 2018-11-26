namespace Microservice.DataAccess.Core.Interfaces
{
    public interface IDataAccessReadOnlyService
    {
        IDataAccessReadOnlyRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}