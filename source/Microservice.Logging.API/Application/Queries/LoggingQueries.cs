using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Logging.API.Application.ViewModels;
using Microservice.Logging.Domain.ExceptionLoggingAggregate;

namespace Microservice.Logging.API.Application.Queries
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
            return Task.FromResult(this._readOnlyService.Repository<ExceptionLogging>().Get().Select(i => new LogViewModel()).ToList());
        }
    }
}