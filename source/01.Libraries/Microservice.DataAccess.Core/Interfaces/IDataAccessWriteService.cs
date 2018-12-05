namespace Microservice.DataAccess.Core.Interfaces
{
    public interface IDataAccessWriteService: IDataAccessService
    {
        void SaveChanges();
    }
}