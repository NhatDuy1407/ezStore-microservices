using System;
using Microservice.Service.UserService.Models;

namespace Microservice.Service.UserService.WriteSide.Interfaces
{
    public interface IWriteUserService
    {
        Guid Add(AppUserDto entity);
        void Delete(Guid id);
    }
}
