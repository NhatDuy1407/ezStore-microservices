using System;
using RKSystem.UserService.Models;

namespace RKSystem.UserService.WriteSide.Interfaces
{
    public interface IUserService
    {
        Guid Add(AppUserDto entity);
        void Delete(Guid id);
    }
}
