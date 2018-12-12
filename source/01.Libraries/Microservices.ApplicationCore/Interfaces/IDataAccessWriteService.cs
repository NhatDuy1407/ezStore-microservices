namespace Microservices.ApplicationCore.Interfaces
{
    public interface IDataAccessWriteService: IDataAccessService
    {
        void SaveChanges();
    }
}