namespace Ws4vn.Microservicess.ApplicationCore.Interfaces
{
    public interface IDataAccessService
    {
        IDataAccessWriteRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}