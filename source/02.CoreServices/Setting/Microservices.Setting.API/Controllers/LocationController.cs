using Microservices.Setting.API.Mappers;
using Microservices.Setting.API.ViewModels;
using Microservices.Setting.ApplicationCore.Services.Commands;
using Microservices.Setting.ApplicationCore.Services.Queries;
using Ws4vn.Microservicess.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.Setting.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly ILocationQueries _queries;

        public LocationController(ICommandBus commandBus, ILocationQueries queries)
        {
            _commandBus = commandBus;
            _queries = queries;
        }

        [HttpGet("Country")]
        public IEnumerable<CountryViewModel> GetCountries()
        {
            return LocationViewMapper.DtoToViewModels(_queries.GetCountries().Result);
        }

        [HttpGet("Country/{id}")]
        public CountryViewModel GetCountry(int id)
        {
            return LocationViewMapper.DtoToViewModel(_queries.GetCountry(id).Result);
        }

        [HttpPost("Country")]
        public Task CreateCountry([FromBody] string name)
        {
            var command = new CreateCountryCommand(name);
            _commandBus.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }

        [HttpPut("Country/{id}")]
        public Task UpdateCountry(string id, [FromBody] string name)
        {
            var command = new UpdateCountryCommand(id, name);
            _commandBus.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }

        [HttpDelete("Country/{id}")]
        public Task Delete(string id)
        {
            var command = new DeleteCountryCommand(id);
            _commandBus.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }
    }
}