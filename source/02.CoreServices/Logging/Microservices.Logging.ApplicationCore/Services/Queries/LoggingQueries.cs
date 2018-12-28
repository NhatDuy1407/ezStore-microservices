using Microservices.Logging.ApplicationCore.Dtos;
using Microservices.Logging.ApplicationCore.Entities;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservices.DataAccess.Core.Entities;

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

        public Task<PagedResult<LogDto>> GetPaged(string orderBy = "", bool orderAsc = true, int page = 1, int pageSize = 20)
        {
            var data = _readOnlyService.Repository<LogData>().GetPaged(i => true, orderBy, orderAsc,
                page: page,
                pageSize: pageSize);
            var result = new PagedResult<LogDto>
            {
                CurrentPage = data.CurrentPage,
                PageCount = data.PageCount,
                PageSize = data.PageSize,
                RowCount = data.RowCount,
                Results = data.Results.Select(i => new LogDto(i)).ToList()
            };
            return Task.FromResult(result);
        }
    }
}