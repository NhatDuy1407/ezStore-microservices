using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RKSystem.UserService.Models;

namespace RKSystem.UserService.Services
{
    public interface IUserService
    {
        AppUserDto Get(Guid id);
        void Add(AppUserDto entity);
        void Delete(Guid id);
        List<AppUserDto> Get();
    }
}
