using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Logging.Domain.Application.ViewModels;
using Microservice.Logging.Persistence.Model;

namespace Microservice.Logging.Domain.Application.Queries
{
    public class LoggingQueries : ILoggingQueries
    {
        private readonly IReadOnlyService _readOnlyService;

        public LoggingQueries(IReadOnlyService readOnlyService)
        {
            this._readOnlyService = readOnlyService;
        }

        public Task<List<LogViewModel>> GetLogs()
        {
            return Task.FromResult(this._readOnlyService.Repository<LogData>().Get().Select(i => new LogViewModel(i)).ToList());
        }
    }
}