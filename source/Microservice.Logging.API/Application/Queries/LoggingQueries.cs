using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Logging.API.Application.ViewModels;
using Microservice.Logging.Persistence.Model;

namespace Microservice.Logging.API.Application.Queries
{
    public class LoggingQueries : ILoggingQueries
    {
        private readonly IReadOnlyService _readOnlyService;

        public LoggingQueries(IReadOnlyService readOnlyService)
        {
            this._readOnlyService = readOnlyService;
        }

        public Task<List<LogViewModel>> GetExceptionLogs()
        {
            return Task.FromResult(this._readOnlyService.Repository<ExceptionLog>().Get().Select(i => new LogViewModel(i)).ToList());
        }

        public Task<List<LogViewModel>> GetAuditLogs()
        {
            return Task.FromResult(this._readOnlyService.Repository<AuditLog>().Get().Select(i => new LogViewModel(i)).ToList());
        }
    }
}