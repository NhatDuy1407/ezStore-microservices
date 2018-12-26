using System.Threading.Tasks;

namespace Microservices.FileSystem.ApplicationCore.Interfaces
{
    public interface IFSRepository
    {
        Task<string> UploadFile(string filename, byte[] source);
    }
}
