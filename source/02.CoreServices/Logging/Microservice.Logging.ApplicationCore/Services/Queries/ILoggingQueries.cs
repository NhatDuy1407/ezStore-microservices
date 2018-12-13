using Microservice.Logging.ApplicationCore.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservice.Logging.ApplicationCore.Services.Queries
{
    public interface ILoggingQueries
    {
        Task<List<LogDto>> GetLogs();
    }
}