using System;
using Microservice.Core.CachingService.Interfaces;
using Microservice.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microservice.Service.UserService.API.ViewModels;
using Microservice.Service.UserService.Models;
using Microservice.Service.UserService.Models.Commands;
using Microservice.Service.UserService.Interfaces;

namespace Microservice.Service.UserService.API.Controllers
{
    [Route("api/[controller]")]
    public class MemberController : BaseController
    {
        private readonly IUserService _clientService;
        private readonly ICacheService _cacheService;
        public MemberController(IUserService clientService, ICommandBus commandBus, ICacheService cacheService) : base(commandBus)
        {
            _clientService = clientService;
            _cacheService = cacheService;
        }

        [HttpGet("{id}")]
        public IActionResult Member(Guid id)
        {
            var client = _clientService.Get(id);
            return Json(client);
        }

        [HttpGet("GetAllClient")]
        public IActionResult Member()
        {
            var client = _clientService.Get();
            return Json(client);
        }

        [HttpPost]
        public IActionResult Member([FromBody]UserVm info)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateUserCommand(AutoMapper.Mapper.Map<AppUserDto>(info));
                CommandBus.ExecuteAsync(command).Wait();

                // get from cache
                var newId = _cacheService.Get<Guid>(command.CommandId).Result;

                var newData = _clientService.Get(newId);
                return Json(newData);
            }
            return Ok(true);
        }
    }
}
