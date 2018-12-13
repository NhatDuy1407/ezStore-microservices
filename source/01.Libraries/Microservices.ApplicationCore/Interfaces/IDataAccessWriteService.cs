namespace Ws4vn.Microservices.ApplicationCore.Interfaces
{
    public interface IDataAccessWriteService: IDataAccessService
    {
        void SaveChanges();
    }
}