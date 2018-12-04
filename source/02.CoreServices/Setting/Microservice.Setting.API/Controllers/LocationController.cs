using Microservice.Core.DomainService.Interfaces;
using Microservice.Setting.API.Mappers;
using Microservice.Setting.API.ViewModels;
using Microservice.Setting.Domain.Application.Commands;
using Microservice.Setting.Domain.Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservice.Setting.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ICommandProcessor _commandProcessor;
        private readonly ILocationQueries _queries;

        public LocationController(ICommandProcessor commandProcessor, ILocationQueries queries)
        {
            _commandProcessor = commandProcessor;
            _queries = queries;
        }

        [HttpGet]
        public IEnumerable<CountryViewModel> Get()
        {
            return LocationViewMapper.DtoToViewModels(_queries.Get().Result);
        }

        [HttpGet("{id}")]
        public CountryViewModel Get(string id)
        {
            return LocationViewMapper.DtoToViewModel(_queries.Get(id).Result);
        }

        [HttpPost]
        public Task Put([FromBody] string name)
        {
            var command = new CreateCountryCommand(name);
            _commandProcessor.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }

        [HttpPut("{id}")]
        public Task Post(string id, [FromBody] string name)
        {
            var command = new UpdateCountryCommand(id, name);
            _commandProcessor.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }

        [HttpDelete("{id}")]
        public Task Delete(string id)
        {
            var command = new DeleteCountryCommand(id);
            _commandProcessor.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }
    }
}