using Microservice.Logging.API.Mappers;
using Microservice.Logging.API.ViewModels;
using Microservice.Logging.ApplicationCore.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.Logging.API.Controllers
{
    [Route("api/[controller]")]
    public class LoggingController : Controller
    {
        private readonly ILoggingQueries _loggingQueries;

        public LoggingController(ILoggingQueries loggingQueries)
        {
            _loggingQueries = loggingQueries;
        }

        // GET api/values
        [HttpGet]
        [Route("Logs")]
        public Task<List<LogViewModel>> Logs()
        {
            return Task.FromResult(LogMapper.DtoToViewModels(_loggingQueries.GetLogs().Result).ToList());
        }
    }
}