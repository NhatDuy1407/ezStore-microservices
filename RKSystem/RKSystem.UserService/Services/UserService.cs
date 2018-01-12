using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using RKSystem.DataAccess.MongoDB;
using RKSystem.DataAccess.MongoDB.Interfaces;
using RKSystem.UserService.Data.Entities;
using RKSystem.UserService.Models;

namespace RKSystem.UserService.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<AppUserDto> Get()
        {
            return AutoMapper.Mapper.Map<List<AppUserDto>>(UnitOfWork.Repository<AppUser>().Get().ToList());
        }

        public void Add(AppUserDto entity)
        {
            var user = AutoMapper.Mapper.Map<AppUser>(entity);
            UnitOfWork.Repository<AppUser>().Insert(user);
        }

        public void Delete(Guid id)
        {
            UnitOfWork.Repository<AppUser>().Delete(i => i.Id == id);
        }

        public AppUserDto Get(Guid id)
        {
            return AutoMapper.Mapper.Map<AppUserDto>(UnitOfWork.Repository<AppUser>().FirstOrDefault(i => i.Id == id));
        }
    }
}
