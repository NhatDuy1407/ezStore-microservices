using System;
using System.Collections.Generic;
using Microservice.Service.UserService.Models;

namespace Microservice.Service.UserService.Interfaces
{
    public interface IUserService
    {
        AppUserDto Get(Guid id);
        List<AppUserDto> Get();
    }
}
