using Microservice.DataAccess.Core.Interfaces;
using Microservice.Logging.ApplicationCore.Dtos;
using Microservice.Logging.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.Logging.ApplicationCore.Application.Queries
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