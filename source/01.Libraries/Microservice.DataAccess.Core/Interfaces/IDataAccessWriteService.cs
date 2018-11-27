namespace Microservice.DataAccess.Core.Interfaces
{
    public interface IDataAccessWriteService
    {
        IDataAccessWriteRepository<TEntity> Repository<TEntity>() where TEntity : class;

        void SaveChanges();
    }
}