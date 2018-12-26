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
    public class ProductController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IProductQueries _queries;

        public ProductController(ICommandBus commandBus, IProductQueries queries)
        {
            _commandBus = commandBus;
            _queries = queries;
        }

        [HttpGet]
        public Task<PagedResult<ProductViewModel>> GetPaged(string name, string orderBy = "", bool orderAsc = true, int page = 1, int pageSize = 20)
        {
            var data = _queries.GetPaged(name, orderBy, orderAsc, page, pageSize).Result;
            var result = new PagedResult<ProductViewModel>
            {
                CurrentPage = data.CurrentPage,
                PageCount = data.PageCount,
                PageSize = data.PageSize,
                RowCount = data.RowCount,
                Results = ProductMapper.DtoToViewModels(data.Results)
            };
            return Task.FromResult(result);
        }

        [HttpGet("{id}")]
        public ProductViewModel Get(Guid id)
        {
            return ProductMapper.DtoToViewModel(_queries.Get(id).Result);
        }

        [HttpPut]
        public Task Put([FromBody] string name)
        {
            var command = new CreateProductCommand(name);
            _commandBus.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }

        [HttpPost("{id}")]
        public Task Post(Guid id, [FromBody] string name)
        {
            var command = new UpdateProductCommand(id, name);
            _commandBus.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }

        [HttpDelete("{id}")]
        public Task Delete(Guid id)
        {
            var command = new DeleteProductCommand(id);
            _commandBus.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }
    }
}