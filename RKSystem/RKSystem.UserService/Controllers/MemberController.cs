using System;
using Microsoft.AspNetCore.Mvc;
using RKSystem.UserService.Models;
using RKSystem.UserService.Services;

namespace RKSystem.UserService.Controllers
{
    [Route("api/[controller]")]
    public class MemberController : Controller
    {
        private readonly IUserService _clientService;

        public MemberController(IUserService clientService)
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
        public IActionResult Member(AppUserDto info)
        {
            _clientService.Add(info);
            return Json(true);
        }
    }
}
