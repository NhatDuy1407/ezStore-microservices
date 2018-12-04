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
        private readonly ICommandProcessor _commandProcessor;
        private readonly IProductCategoryQueries _queries;

        public ProductCategoryController(ICommandProcessor commandProcessor, IProductCategoryQueries queries)
        {
            _commandProcessor = commandProcessor;
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

        [HttpPost]
        public Task Put([FromBody] string name)
        {
            var command = new CreateProductCategoryCommand(name);
            _commandProcessor.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }

        [HttpPut("{id}")]
        public Task Post(Guid id, [FromBody] string name)
        {
            var command = new UpdateProductCategoryCommand(id, name);
            _commandProcessor.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }

        [HttpDelete("{id}")]
        public Task Delete(Guid id)
        {
            var command = new DeleteProductCategoryCommand(id);
            _commandProcessor.ExecuteAsync(command).Wait();
            return Task.CompletedTask;
        }
    }
}
