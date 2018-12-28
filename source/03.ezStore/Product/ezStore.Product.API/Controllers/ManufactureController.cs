using ezStore.Product.API.Mappers;
using ezStore.Product.API.ViewModels;
using ezStore.Product.ApplicationCore.Services.Commands;
using ezStore.Product.ApplicationCore.Services.Queries;
using Microservices.DataAccess.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace ezStore.Product.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ManufactureController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IManufactureQueries _queries;

        public ManufactureController(ICommandBus commandBus, IManufactureQueries queries)
        {
            _commandBus = commandBus;
            _queries = queries;
        }

        [HttpGet]
        public Task<PagedResult<ManufactureViewModel>> GetPaged(string name, string orderBy = "", bool orderAsc = true, int page = 1, int pageSize = 20)
        {
            var data = _queries.GetPaged(name, orderBy, orderAsc, page, pageSize).Result;
            var result = new PagedResult<ManufactureViewModel>
            {
                CurrentPage = data.CurrentPage,
                PageCount = data.PageCount,
                PageSize = data.PageSize,
                RowCount = data.RowCount,
                Results = ManufactureMapper.DtoToViewModels(data.Results)
            };
            return Task.FromResult(result);
        }

        [HttpGet("{id}")]
        public ManufactureViewModel Get(Guid id)
        {
            return ManufactureMapper.DtoToViewModel(_queries.Get(id).Result);
        }

        [HttpPut]
        public Task Put([FromBody] string name)
        {
            var command = new CreateManufactureCommand(name);
            _commandBus.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }

        [HttpPost("{id}")]
        public Task Post(Guid id, [FromBody] string name)
        {
            var command = new UpdateManufactureCommand(id, name);
            _commandBus.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }

        [HttpDelete("{id}")]
        public Task Delete(Guid id)
        {
            var command = new DeleteManufactureCommand(id);
            _commandBus.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }
    }
}