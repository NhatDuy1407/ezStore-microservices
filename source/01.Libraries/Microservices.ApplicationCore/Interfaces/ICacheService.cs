using System.Threading.Tasks;

namespace Ws4vn.Microservices.ApplicationCore.Interfaces
{
    public interface ICacheService
    {
        Task Set<T>(string key, T data);

        Task<T> Get<T>(string key);
    }
}
