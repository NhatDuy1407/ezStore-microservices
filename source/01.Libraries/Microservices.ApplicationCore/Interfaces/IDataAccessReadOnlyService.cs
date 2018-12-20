namespace Ws4vn.Microservices.ApplicationCore.Interfaces
{
    public interface IDataAccessReadOnlyService
    {
        IDataAccessReadOnlyRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}