using System;
using System.Collections.Generic;
using RKSystem.UserService.Models;

namespace RKSystem.UserService.ReadSide.Interfaces
{
    public interface IUserService
    {
        AppUserDto Get(Guid id);
        //void Add(AppUserDto entity);
        //void Delete(Guid id);
        List<AppUserDto> Get();
    }
}
