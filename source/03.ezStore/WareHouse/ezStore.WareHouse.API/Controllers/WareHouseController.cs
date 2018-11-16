using ezStore.WareHouse.API.Mappers;
using ezStore.WareHouse.API.ViewModels;
using ezStore.WareHouse.Domain.Application.Commands;
using ezStore.WareHouse.Domain.Application.Queries;
using Microservice.Core.DomainService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ezStore.WareHouse.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WareHouseController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IWareHouseQueries _queries;

        public WareHouseController(ICommandBus commandBus, IWareHouseQueries queries)
        {
            _commandBus = commandBus;
            _queries = queries;
        }

        [HttpGet]
        public IEnumerable<WareHouseViewModel> Get()
        {
            return WareHouseViewMapper.DtoToViewModels(_queries.Get().Result);
        }

        [HttpGet("{id}")]
        public WareHouseViewModel Get(Guid id)
        {
            return WareHouseViewMapper.DtoToViewModel(_queries.Get(id).Result);
        }

        [HttpPut]
        public Task Put([FromBody] string name)
        {
            var command = new CreateWareHouseCommand(name);
            _commandBus.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }

        [HttpPost("{id}")]
        public Task Post(Guid id, [FromBody] string name)
        {
            var command = new UpdateWareHouseCommand(id, name);
            _commandBus.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }

        [HttpDelete("{id}")]
        public Task Delete(Guid id)
        {
            var command = new DeleteWareHouseCommand(id);
            _commandBus.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }
    }
}