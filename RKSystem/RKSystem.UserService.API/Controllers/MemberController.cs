using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RKSystem.Service.Core.Interfaces;
using RKSystem.UserService.API.ViewModels;
using RKSystem.UserService.Models;
using RKSystem.UserService.Models.Commands;
using RKSystem.UserService.ReadSide.Interfaces;

namespace RKSystem.UserService.API.Controllers
{
    [Route("api/[controller]")]
    public class MemberController : BaseController
    {
        private readonly IUserService _clientService;

        public MemberController(IUserService clientService, ICommandBus commandBus) : base(commandBus)
        {
            _clientService = clientService;
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
                //result.Data = command.NewId;
                //result.Code = ResponseResultCode.Ok;
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
