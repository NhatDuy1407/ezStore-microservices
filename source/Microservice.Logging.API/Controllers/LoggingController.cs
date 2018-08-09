using System.Collections.Generic;
using System.Threading.Tasks;
using Microservice.Core.Interfaces;
using Microservice.Logging.API.Application.Queries;
using Microservice.Logging.API.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            return Task.FromResult(_loggingQueries.GetLogs().Result);
        }
    }
}