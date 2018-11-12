using ezStore.Product.Domain.Application.Queries;
using ezStore.WareHouse.API.Mappers;
using ezStore.WareHouse.API.ViewModels;
using Microservice.Core.DomainService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
    }
}