using Microservice.Logging.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservice.Logging.Domain.Application.Queries
{
    public interface ILoggingQueries
    {
        Task<List<LogDto>> GetLogs();
    }
}