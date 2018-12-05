namespace Microservice.DataAccess.Core.Interfaces
{
    public interface IDataAccessService
    {
        IDataAccessWriteRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}