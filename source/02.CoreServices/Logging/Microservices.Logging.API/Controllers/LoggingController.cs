using Microservices.DataAccess.Core.Entities;
using Microservices.Logging.API.Mappers;
using Microservices.Logging.API.ViewModels;
using Microservices.Logging.ApplicationCore.Services.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservices.Logging.API.Controllers
{
    [Route("api/[controller]")]
    public class LoggingController : Controller
    {
        private readonly ILoggingQueries _loggingQueries;

        public LoggingController(ILoggingQueries loggingQueries)
        {
            _loggingQueries = loggingQueries;
        }

        [HttpGet]
        [Route("Logs")]
        public Task<PagedResult<LogViewModel>> GetPaged(string orderBy = "", bool orderAsc = true, int page = 1, int pageSize = 20)
        {
            var data = _loggingQueries.GetPaged(orderBy, orderAsc, page, pageSize).Result;
            var result = new PagedResult<LogViewModel>
            {
                CurrentPage = data.CurrentPage,
                PageCount = data.PageCount,
                PageSize = data.PageSize,
                RowCount = data.RowCount,
                Results = LogMapper.DtoToViewModels(data.Results)
            };
            return Task.FromResult(result);
        }
    }
}