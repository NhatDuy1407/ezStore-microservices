using System;
using System.Collections.Generic;
using RKSystem.UserService.Models;

namespace RKSystem.UserService.Interfaces
{
    public interface IUserService
    {
        AppUserDto Get(Guid id);
        List<AppUserDto> Get();
    }
}
