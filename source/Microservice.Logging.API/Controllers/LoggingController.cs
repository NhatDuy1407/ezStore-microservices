using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.Core.Service.Interfaces;
using Microservice.Logging.API.Application.Commands;
using Microservice.Logging.API.Application.Queries;
using Microservice.Logging.API.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Logging.API.Controllers
{
    [Route("api/[controller]")]
    public class LoggingController : Controller
    {
        private readonly ILoggingQueries _loggingQueries;
        protected readonly ICommandBus CommandBus;

        public LoggingController(ILoggingQueries loggingQueries, ICommandBus commandBus)
        {
            CommandBus = commandBus;
            _loggingQueries = loggingQueries;
        }

        // GET api/values
        [HttpGet]
        public Task<List<LogViewModel>> Get()
        {
            return Task.FromResult(_loggingQueries.GetLogs().Result);
        }

        [HttpPost]
        public IActionResult Log([FromBody]LogViewModel info)
        {
            if (ModelState.IsValid)
            {
                var command = new AddExceptionLogCommand(info);
                CommandBus.ExecuteAsync(command).Wait();
                return Ok();
            }
            return Ok(true);
        }
    }
}