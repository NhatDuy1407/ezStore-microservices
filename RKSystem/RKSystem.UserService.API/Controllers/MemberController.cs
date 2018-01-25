using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Util;
using Microsoft.AspNetCore.Mvc;
using RKSystem.CacheService.Interfaces;
using RKSystem.Service.Core.Interfaces;
using RKSystem.UserService.API.ViewModels;
using RKSystem.UserService.Interfaces;
using RKSystem.UserService.Models;
using RKSystem.UserService.Models.Commands;

namespace RKSystem.UserService.API.Controllers
{
    [Route("api/[controller]")]
    public class MemberController : BaseController
    {
        private readonly IUserService _clientService;
        private readonly ICacheService _cacheService;
        public MemberController(IUserService clientService, ICommandBus commandBus, ICacheService cacheService) : base(commandBus)
        {
            _clientService = clientService;
            _cacheService = new CacheService.CacheService();
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
        public IActionResult Member(UserVm info)
        {
            //var result = new ResultObject();
            if (ModelState.IsValid)
            {
                var command = new CreateUserCommand(AutoMapper.Mapper.Map<AppUserDto>(info));
                CommandBus.ExecuteAsync(command).Wait();

                // get from cache
                var newId = _cacheService.Get<Guid>(command.CommandId).Result;

                var newData = _clientService.Get(newId);
                return Json(newData);
            }
            else
            {
                //result = CreateResponseResultFromModelState(ModelState);
            }

            //return Task.FromResult(result);
            //_clientService.Add(info);
            //return Json(true);
            return Ok(true);
        }
    }
}
