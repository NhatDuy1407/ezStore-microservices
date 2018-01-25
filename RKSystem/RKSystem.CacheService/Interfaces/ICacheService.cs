using System;
using System.Threading.Tasks;

namespace RKSystem.CacheService.Interfaces
{
    public interface ICacheService
    {
        Task Set<T>(Guid key, T data);

        Task<T> Get<T>(Guid key);
    }
}
