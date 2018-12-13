namespace Microservices.ApplicationCore.Interfaces
{
    public interface IDataAccessService
    {
        IDataAccessWriteRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}