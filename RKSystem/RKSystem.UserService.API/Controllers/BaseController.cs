using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RKSystem.Service.Core.Interfaces;

namespace RKSystem.UserService.API.Controllers
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
