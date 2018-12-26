using ezStore.Product.API.Mappers;
using ezStore.Product.API.ViewModels;
using ezStore.Product.ApplicationCore.Services.Commands;
using ezStore.Product.ApplicationCore.Services.Queries;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microservices.DataAccess.Core.Entities;

namespace ezStore.Product.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IProductCategoryQueries _queries;

        public ProductCategoryController(ICommandBus commandBus, IProductCategoryQueries queries)
        {
            _commandBus = commandBus;
            _queries = queries;
        }

        [HttpGet]
        public Task<PagedResult<ProductCategoryViewModel>> GetPaged(string name, string orderBy = "", bool orderAsc = true, int page = 1, int pageSize = 20)
        {
            var data = _queries.GetPaged(name, orderBy, orderAsc, page, pageSize).Result;
            var result = new PagedResult<ProductCategoryViewModel>
            {
                CurrentPage = data.CurrentPage,
                PageCount = data.PageCount,
                PageSize = data.PageSize,
                RowCount = data.RowCount,
                Results = ProductCategoryMapper.DtoToViewModels(data.Results)
            };
            return Task.FromResult(result);
        }

        [HttpGet("{id}")]
        public ProductCategoryViewModel Get(Guid id)
        {
            return ProductCategoryMapper.DtoToViewModel(_queries.Get(id).Result);
        }

        [HttpPut]
        public Task Put([FromBody] string name)
        {
            var command = new CreateProductCategoryCommand(name);
            _commandBus.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }

        [HttpPost("{id}")]
        public Task Post(Guid id, [FromBody] string name)
        {
            var command = new UpdateProductCategoryCommand(id, name);
            _commandBus.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }

        [HttpDelete("{id}")]
        public Task Delete(Guid id)
        {
            var command = new DeleteProductCategoryCommand(id);
            _commandBus.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }
    }
}
