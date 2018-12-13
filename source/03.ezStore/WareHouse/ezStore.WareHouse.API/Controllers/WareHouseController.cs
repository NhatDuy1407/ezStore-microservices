using ezStore.WareHouse.API.Mappers;
using ezStore.WareHouse.API.ViewModels;
using ezStore.WareHouse.ApplicationCore.Services.Commands;
using ezStore.WareHouse.ApplicationCore.Services.Queries;
using Microservice.DataAccess.Core.Entities;
using Microservices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public Task<PagedResult<WareHouseViewModel>> GetPaged(string name, string orderBy = "", bool orderAsc = true, int page = 1, int pageSize = 20)
        {
            var data = _queries.GetPaged(name, orderBy, orderAsc, page, pageSize).Result;
            var result = new PagedResult<WareHouseViewModel>
            {
                CurrentPage = data.CurrentPage,
                PageCount = data.PageCount,
                PageSize = data.PageSize,
                RowCount = data.RowCount,
                Results = WareHouseViewMapper.DtoToViewModels(data.Results)
            };
            return Task.FromResult(result);
        }

        [HttpGet("{id}")]
        public Task<WareHouseViewModel> Get(Guid id)
        {
            return Task.FromResult(WareHouseViewMapper.DtoToViewModel(_queries.Get(id).Result));
        }

        [HttpPost]
        public Task Put([FromBody] CreateWareHouseCommand command)
        {
            _commandBus.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }

        [HttpPut("{id}")]
        public Task Post(Guid id, [FromBody] UpdateWareHouseCommand command)
        {
            command.Id = id;
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