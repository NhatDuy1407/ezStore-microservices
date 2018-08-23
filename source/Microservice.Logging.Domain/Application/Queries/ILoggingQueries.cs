using System.Collections.Generic;
using System.Threading.Tasks;
using Microservice.Logging.Domain.Application.ViewModels;

namespace Microservice.Logging.Domain.Application.Queries
{
    public interface ILoggingQueries
    {
        Task<List<LogViewModel>> GetLogs();
    }
}