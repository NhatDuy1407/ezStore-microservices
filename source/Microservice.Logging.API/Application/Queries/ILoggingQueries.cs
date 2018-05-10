using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.Logging.API.Application.ViewModels;

namespace Microservice.Logging.API.Application.Queries
{
    public interface ILoggingQueries
    {
        Task<List<LogViewModel>> GetLogs();
    }
}