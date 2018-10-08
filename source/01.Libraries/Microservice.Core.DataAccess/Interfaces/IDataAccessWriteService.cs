namespace Microservice.Core.DataAccess.Interfaces
{
    public interface IDataAccessWriteService
    {
        IDataAccessWriteRepository<TEntity> Repository<TEntity>() where TEntity : class;

        void SaveChanges();
    }
}