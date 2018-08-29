namespace Microservice.Core.DataAccess.Interfaces
{
    public interface IReadOnlyService
    {
        IReadOnlyRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}