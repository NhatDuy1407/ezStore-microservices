using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Util;
using Microsoft.AspNetCore.Mvc;
using RKSystem.CacheService.Interfaces;
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

        private IBusControl busControl;

        public MemberController(IUserService clientService, ICommandBus commandBus) : base(commandBus)
        {
            _clientService = clientService;

            busControl = Bus.Factory.CreateUsingRabbitMq(x =>
           {
               x.Host(new Uri("rabbitmq://192.168.0.101"), h =>
               {
                    //h.Username("guest");
                    //h.Password("guest");
                });

           });

            TaskUtil.Await(() => busControl.StartAsync());
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
                //CommandBus.ExecuteAsync(command).Wait();

                var serviceAddress = new Uri("rabbitmq://192.168.0.101/user_service");
                IRequestClient<CreateUserCommand, CreateUserCommand> client = busControl.CreateRequestClient<CreateUserCommand, CreateUserCommand>(serviceAddress, TimeSpan.FromSeconds(500));
                var result = client.Request(command).Result;

                // todo: subcribe event

                // get from cache, for special data
                //ICacheService cacheService = new CacheService.CacheService();
                //var newId = cacheService.Get<Guid>(command.CommandId).Result;

                var newData = _clientService.Get(result.NewId);
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
