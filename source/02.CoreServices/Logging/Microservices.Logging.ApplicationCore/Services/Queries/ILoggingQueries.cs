using Microservices.DataAccess.Core.Entities;
using Microservices.Logging.ApplicationCore.Dtos;
using System.Threading.Tasks;

namespace Microservices.Logging.ApplicationCore.Services.Queries
{
    public interface ILoggingQueries
    {
        Task<PagedResult<LogDto>> GetPaged(string orderBy, bool orderAsc, int page, int pageSize);
    }
}