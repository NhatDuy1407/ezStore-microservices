using ezStore.WareHouse.API.Mappers;
using ezStore.WareHouse.API.ViewModels;
using ezStore.WareHouse.ApplicationCore.Application.Commands;
using ezStore.WareHouse.ApplicationCore.Application.Queries;
using Microservice.Core.DomainService.Interfaces;
using Microservice.DataAccess.Core.Entities;
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
        private readonly ICommandProcessor _commandProcessor;
        private readonly IWareHouseQueries _queries;

        public WareHouseController(ICommandProcessor commandProcessor, IWareHouseQueries queries)
        {
            _commandProcessor = commandProcessor;
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
            _commandProcessor.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }

        [HttpPut("{id}")]
        public Task Post(Guid id, [FromBody] UpdateWareHouseCommand command)
        {
            command.Id = id;
            _commandProcessor.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }

        [HttpDelete("{id}")]
        public Task Delete(Guid id)
        {
            var command = new DeleteWareHouseCommand(id);
            _commandProcessor.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }
    }
}