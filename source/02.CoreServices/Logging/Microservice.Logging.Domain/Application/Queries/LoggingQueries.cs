using Microservice.Logging.Domain.Dtos;
using Microservice.Logging.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ws4vn.DataAccess.Core.Interfaces;

namespace Microservice.Logging.Domain.Application.Queries
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