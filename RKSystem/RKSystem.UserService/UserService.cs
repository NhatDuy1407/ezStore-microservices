using System;
using System.Collections.Generic;
using MongoDB.Driver;
using RKSystem.DataAccess.MongoDB.Interfaces;
using RKSystem.UserService.Data.Entities;
using RKSystem.UserService.Interfaces;
using RKSystem.UserService.Models;

namespace RKSystem.UserService
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
