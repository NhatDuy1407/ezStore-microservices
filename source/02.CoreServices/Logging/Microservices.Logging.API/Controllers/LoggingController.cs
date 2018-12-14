using Microservices.Logging.API.Mappers;
using Microservices.Logging.API.ViewModels;
using Microservices.Logging.ApplicationCore.Services.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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

        // GET api/values
        [HttpGet]
        [Route("Logs")]
        public Task<List<LogViewModel>> Logs()
        {
            return Task.FromResult(LogMapper.DtoToViewModels(_loggingQueries.GetLogs().Result).ToList());
        }
    }
}