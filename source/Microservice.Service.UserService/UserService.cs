using System;
using System.Collections.Generic;
using System.Linq;
using Microservice.Core.DataAccess.Interfaces;
using Microservice.Service.UserService.Interfaces;
using Microservice.Service.UserService.Models;
using Microservice.Service.UserService.Entities;

namespace Microservice.Service.UserService
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IReadOnlyService service) : base(service)
        {
        }

        public List<AppUserDto> Get()
        {
            return AutoMapper.Mapper.Map<List<AppUserDto>>(Service.Repository<AppUser>().Get().ToList());
        }

        public AppUserDto Get(Guid id)
        {
            return AutoMapper.Mapper.Map<AppUserDto>(Service.Repository<AppUser>().FirstOrDefault(i => i.Id == id));
        }
    }
}
