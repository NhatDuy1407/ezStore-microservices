using Microservice.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Service.UserService.API.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ICommandBus CommandBus;

        public BaseController(ICommandBus commandBus)
        {
            CommandBus = commandBus;
        }
    }
}
