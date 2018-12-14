namespace Ws4vn.Microservicess.ApplicationCore.Interfaces
{
    public interface IDataAccessWriteService: IDataAccessService
    {
        void SaveChanges();
    }
}