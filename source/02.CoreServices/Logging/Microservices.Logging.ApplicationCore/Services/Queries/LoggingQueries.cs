using Microservices.Logging.ApplicationCore.Dtos;
using Microservices.Logging.ApplicationCore.Entities;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Logging.ApplicationCore.Services.Queries
{
    public class LoggingQueries : ILoggingQueries
    {
        private readonly IDataAccessReadOnlyService _readOnlyService;

        public LoggingQueries(IDataAccessReadOnlyService readOnlyService)
        {
            this._readOnlyService = readOnlyService;
        }

        public Task<List<LogDto>> GetLogs()
        {
            return Task.FromResult(this._readOnlyService.Repository<LogData>().Get().Select(i => new LogDto(i)).ToList());
        }
    }
}