using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ezStore.Product.API.Mappers;
using ezStore.Product.API.ViewModels;
using ezStore.Product.Domain.Application.Commands;
using ezStore.Product.Domain.Application.Queries;
using Microservice.Core.DomainService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ezStore.Product.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ICommandProcessor _commandBus;
        private readonly IProductCategoryQueries _queries;

        public ProductCategoryController(ICommandProcessor commandBus, IProductCategoryQueries queries)
        {
            _commandBus = commandBus;
            _queries = queries;
        }

        [HttpGet]
        public IEnumerable<ProductCategoryViewModel> Get()
        {
            return ProductCategoryMapper.DtoToViewModels(_queries.Get().Result);
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
