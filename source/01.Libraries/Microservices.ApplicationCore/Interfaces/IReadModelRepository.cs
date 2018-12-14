namespace Ws4vn.Microservicess.ApplicationCore.Interfaces
{
    public interface IReadModelRepository
    {
        void Write<TEntity>(string key, TEntity data);

        TEntity Read<TEntity>(string key);
    }
}
